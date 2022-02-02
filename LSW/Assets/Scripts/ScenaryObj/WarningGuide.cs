using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSW.ScenaryObj
{
    public class WarningGuide : MonoBehaviour
    {
        public GameObject _popUp;

        private void Awake()
        {
            _popUp.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                _popUp.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                _popUp.SetActive(false);
            }
        }
    }
}