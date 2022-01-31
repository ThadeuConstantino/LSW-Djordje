using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSW.Heroe
{
    public class AttackRain : MonoBehaviour
    {
        public float delayDestroy;
        public float speed;

        private void OnEnable()
        {
            Destroy(gameObject, delayDestroy);
        }

        private void Update()
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Zombie"))
            {
                Destroy(gameObject);
            }
        }
    }
}