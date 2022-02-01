using UnityEngine;
using UnityEngine.SceneManagement;

namespace LSW.Menu
{
    public class Menu : MonoBehaviour
    {
        public GameObject _buttonNewGame;
        public GameObject _buttonContinue;
        public GameObject _buttonContinueDisable;

        private void Start()
        {
            _buttonNewGame.SetActive(true);
            _buttonContinue.SetActive(false);
            _buttonContinueDisable.SetActive(true);
        }

        public void NewGame()
        {
            LoadScene("Tier1");
        }

        public void Continue()
        {
            LoadScene("Tier1");
        }

        private void LoadData()
        {

        }

        private void LoadScene(string value)
        {
            SceneManager.LoadScene(value, LoadSceneMode.Single);
        }
    }
}