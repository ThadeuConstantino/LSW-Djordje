using LSW.Static;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LSW.ScenaryObj
{
    public class Portal : MonoBehaviour
    {
        [Header("Name Load New TIER")]
        [SerializeField]
        private int _idTier;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
                StartCoroutine(DelayNewTier());
        }

        IEnumerator DelayNewTier()
        {
            yield return new WaitForSeconds(.5f);
            DataGame.CurrentTier = _idTier;
            SceneManager.LoadScene("Tier" + _idTier.ToString(), LoadSceneMode.Single);
        }
    }
}