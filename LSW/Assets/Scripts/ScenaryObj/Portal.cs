using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LSW.ScenaryObj
{
    public class Portal : MonoBehaviour
    {
        [Header("Name Load New TIER")]
        [SerializeField]
        private string _nameNextTier;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
                StartCoroutine(DelayNewTier());
        }

        IEnumerator DelayNewTier()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(_nameNextTier, LoadSceneMode.Single);
        }
    }
}