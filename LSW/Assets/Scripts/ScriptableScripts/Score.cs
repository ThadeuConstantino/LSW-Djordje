using UnityEngine;
using Sirenix.OdinInspector;

namespace LSW
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "Score", menuName = "LSW/Score", order = 3)]
    public class Score : SerializedScriptableObject
    {
        [SerializeField]
        private int value;

        public int Value { get => value; set => this.value = value; }
    }
}