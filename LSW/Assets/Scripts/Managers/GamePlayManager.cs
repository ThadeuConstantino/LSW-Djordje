using LSW.Static;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace LSW.Managers
{
    public class GamePlayManager : MonoBehaviour
    {
        [Header("Scriptable Hero")]
        public Player _hero;

        [Header("Unity Event")]
        public UnityEvent<bool> OnStartedData;

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }

        public void Init()
        {
            if (!ES3.FileExists())
            {
                CleanData();
                OnStartedData.Invoke(false);
            }
            else
            {
                OnStartedData.Invoke(true);
            }

            Load();
        }

        public void CleanData()
        {
            ES3.Save("CurrentScore", 0);
            ES3.Save("CurrentTier", 1);
            ES3.Save("CurrentHealthHero", _hero.Health);

            Load();
        }

        public void Load()
        {
            DataGame.CurrentScore = ES3.Load<int>("CurrentScore");
            DataGame.CurrentTier = ES3.Load<int>("CurrentTier");
            DataGame.CurrentHealthHero = ES3.Load<int>("CurrentHealthHero");
        }  

        public void Save()
        {
            ES3.Save("CurrentScore", DataGame.CurrentScore);
            ES3.Save("CurrentTier", DataGame.CurrentTier);
            ES3.Save("CurrentHealthHero", DataGame.CurrentHealthHero);
            
        }

        public void GameOver(bool value)
        {
            StartCoroutine(DelayClose(value));
        }

        IEnumerator DelayClose(bool value)
        {
            yield return new WaitForSeconds(2f);
            DataGame.win = value;
            GameObject.Instantiate(Resources.Load(DataGame.PREFAB_ENDGAME) as GameObject);
            Time.timeScale = 0f;
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}