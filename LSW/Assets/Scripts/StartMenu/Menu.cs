using LSW.Managers;
using LSW.Static;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LSW.Menu
{
    public class Menu : MonoBehaviour
    {
        public GameObject _buttonNewGame;
        public GameObject _buttonContinue;
        public GameObject _buttonContinueDisable;

        [Header("Manager Inspector")]
        public GamePlayManager _gamePlayManager;

        private void Start()
        {
            _gamePlayManager.Init();
        }

        private void OnEnable()
        {
            _gamePlayManager.OnStartedData.AddListener(StartedData);
        }

        private void OnDisable()
        {
            _gamePlayManager.OnStartedData.RemoveListener(StartedData);
        }

        private void StartedData(bool value)
        {
            _buttonNewGame.SetActive(true);
            _buttonContinue.SetActive(value);
            _buttonContinueDisable.SetActive(!value);
        }

        public void NewGame()
        {
            _gamePlayManager.CleanData();
            LoadScene("Tier1");
        }

        public void Continue()
        {
            LoadScene("Tier" + DataGame.CurrentTier);
        }

        public void Quit()
        {
            Application.Quit();
        }

        private void LoadScene(string value)
        {
            SceneManager.LoadScene(value, LoadSceneMode.Single);
        }
    }
}