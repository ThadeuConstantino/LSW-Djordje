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
        [SerializeField]
        [BoxGroup("Data Enemy")]
        private int life;
        [SerializeField]
        [BoxGroup("Data Enemy")]
        private int damage;


        //Getters and Setters
        public int Damage { get => damage; set => damage = value; }
        public int Life { get => life; set => life = value; }
    }
}