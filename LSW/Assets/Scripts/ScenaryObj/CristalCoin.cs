using LSW.Static;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSW.ScenaryObj
{
    public class CristalCoin : MonoBehaviour
    {
        [Header("Scriptable Score")]
        public Score _score;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player") 
            {
                DataGame.CurrentScore += _score.Value;
                Destroy(gameObject);
            }
        }
    }
}