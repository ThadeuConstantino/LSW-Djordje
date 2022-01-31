using System.Collections;
using UnityEngine;

namespace LSW.ScenaryObj
{
    public class BreakFloor : MonoBehaviour
    {
        public float time;
        public GameObject particleBreak;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                            gameObject.transform.position.y - .025f,
                                                            gameObject.transform.position.z);
                StartCoroutine(DestroyFloor(other));
            }
        }

        IEnumerator DestroyFloor(Collider2D other)
        {
            yield return new WaitForSeconds(time);

            if (other)
            {
                Instantiate(particleBreak, gameObject.transform.position, gameObject.transform.rotation);

                Destroy(gameObject);
            }
        }
    }
}