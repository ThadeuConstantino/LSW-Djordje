using UnityEngine;

namespace LSW.ScenaryObj
{
    public class VerticalPlataform : MonoBehaviour
    {
        public float TopY;
        public float DownY;
        public float speed;

        void Start()
        {

        }

        private void FixedUpdate()
        {
            float posAuxY = gameObject.transform.position.y + speed;

            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        posAuxY,
                                                        gameObject.transform.position.z
                                                        );

            if (posAuxY > TopY || posAuxY < DownY)
            {
                speed *= -1;
            }
        }
    }
}