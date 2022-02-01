using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSW.Utils
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(this);

            if (GameObject.Find(gameObject.name)
                     && GameObject.Find(gameObject.name) != this.gameObject)
            {
                Destroy(GameObject.Find(gameObject.name));
            }

        }

    }
}