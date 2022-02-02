using UnityEngine;
using Sirenix.OdinInspector;

namespace LSW
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "Enemy", menuName = "LSW/Enemy", order = 3)]
    public class Enemy : SerializedScriptableObject
    {
        [BoxGroup("Scriptable Score")]
        [SerializeField]
        private Score score;

        [SerializeField]
        [BoxGroup("Data Enemy")]
        private int life;
        [SerializeField]
        [BoxGroup("Data Enemy")]
        private int damage;
        [BoxGroup("Data Enemy")]
        [SerializeField]
        private float speed;


        //Getters and Setters
        public int Damage { get => damage; set => damage = value; }
        public int Life { get => life; set => life = value; }
        public Score Score { get => score; set => score = value; }
        public float Speed { get => speed; set => speed = value; }
    }
}