using LSW.Static;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using LSW.Managers;

namespace LSW.MenuGame
{
    public class MenuInGame : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _listHealth;
        [SerializeField]
        private TextMeshProUGUI _textScore;
        [SerializeField]
        private GamePlayManager _gamePlayManager;

        private void OnEnable()
        {
            UpdateHealth();
        }

        private void UpdateHealth()
        {
            RefreshHealth(DataGame.CurrentHealthHero);
        }

        private void Update()
        {
            _textScore.text = "Score: " + DataGame.CurrentScore.ToString();
        }

        public void RefreshHealth(int value)
        {
            for (int i = 1; i <= _listHealth.Count; i++)
            {
                if (i <= value)
                    _listHealth[i - 1].SetActive(true);
                else
                    _listHealth[i - 1].SetActive(false);
            }
        }

        //Close Game
        public void CloseGame()
        {
            _gamePlayManager.Save();
            SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
        }

    }
}