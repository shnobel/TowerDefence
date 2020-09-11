using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerDefence.Runtime
{
    public sealed class DefaultTower : Tower
    {
        protected override void Attack()
        {
            IEnumerable<IHittable> units = GetUnits(1);
            if (units.Any())
            {
                Debug.Log($"{nameof(DefaultTower)}: Attack unit.");
                units.First().Hit(Damage);
                base.Attack();
            }
        }
    }
}
