using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSW.Utils
{
    public class CameraFollow : MonoBehaviour
    {
        private Vector2 velocity;
        private Transform heroe;

        public float smoothTimeX;
        public float smoothTimeY;

        private void Start()
        {
            heroe = GameObject.Find("Heroe").GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            if (heroe == null)
                return;

            float posX = Mathf.SmoothDamp(transform.position.x, heroe.position.x, ref velocity.x, smoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, heroe.position.y, ref velocity.y, smoothTimeY);

            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }
}