using LSW.Static;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSW.ScenaryObj
{
    public class CristalCoin : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);
        }
    }
}