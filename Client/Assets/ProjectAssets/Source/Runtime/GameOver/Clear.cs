using System.Linq;
using UnityEngine;

namespace TowerDefence.Runtime
{
    public class Clear
    {
        public static void Enemy() 
        {
            Object.FindObjectsOfType<EnemyMoveModel>()
                                    .ToList()
                                    .ForEach(enemy => Object.Destroy(enemy.gameObject));
        }
    }
}
