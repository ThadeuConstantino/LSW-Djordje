using LSW.Static;
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
            DataGame.CurrentScore = 0;
            ES3.Save("CurrentScore", 0);
            DataGame.CurrentTier = 1;
            ES3.Save("CurrentTier", 1);
            DataGame.CurrentHealthHero = _hero.Health;
            ES3.Save("CurrentHealthHero", _hero.Health);
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

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}