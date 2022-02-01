using UnityEngine;
using Sirenix.OdinInspector;

namespace LSW
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "Player", menuName = "LSW/Player", order = 3)]
    public class Player : SerializedScriptableObject
    {
        [SerializeField]
        private int health;
        [SerializeField]
        private int speed;
        [SerializeField]
        private float jumpforce;
        [SerializeField]
        private int totalJump;
        [SerializeField]
        private float attackRate;

        //Getters and Setters
        public int Health { get => health; set => health = value; }
        public float AttackRate { get => attackRate; set => attackRate = value; }
        public int TotalJump { get => totalJump; set => totalJump = value; }
        public float Jumpforce { get => jumpforce; set => jumpforce = value; }
        public int Speed { get => speed; set => speed = value; }
    }
}