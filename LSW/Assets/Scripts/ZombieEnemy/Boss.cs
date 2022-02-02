using LSW.Static;
using System.Collections;
using UnityEngine;

namespace LSW.Zombies
{
    public class Boss : ZombieEnemy
    {
        private Rigidbody2D rb2D;

        //Simple BOSS
        public override void Start()
        {
            base.Start();

            rb2D = GetComponent<Rigidbody2D>();

            StartCoroutine(SortingFace());
            StartCoroutine(SortingSpeed());
        }


        public override void Update()
        {
            base.Update();
        }


        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Attack"))
            {
                DamageEnemy();
            }
        }

        private IEnumerator SortingFace()
        {
            int num = Random.Range(0, 6);
            yield return new WaitForSeconds(num);
            int randomFace = Random.Range(0, 10);

            if (randomFace <= 5) tochedWall = true;
            StartCoroutine(SortingFace());
        }

        private IEnumerator SortingSpeed()
        {
            int num = Random.Range(0, 6);
            yield return new WaitForSeconds(num);
            int modificator = 1;
            Speed = Speed > 0 ? modificator = 1 : modificator = -1;
            Speed = Speed + (modificator * Random.Range(2, 6));
            StartCoroutine(SortingSpeed());
        }
    }
}