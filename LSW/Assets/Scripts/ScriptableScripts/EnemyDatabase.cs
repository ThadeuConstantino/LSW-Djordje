using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace LSW
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "EnemyDatabase", menuName = "LSW/EnemyDatabase", order = 1)]
    public class EnemyDatabase : SerializedScriptableObject
    {
        public List<Enemy> _listEnemies;
    }

}