using LSW.Static;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSW.ScenaryObj
{
    public class Life : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                if(DataGame.CurrentHealthHero < 3)
                    DataGame.CurrentHealthHero += 1;

                Destroy(gameObject);
            }
        }
    }
}