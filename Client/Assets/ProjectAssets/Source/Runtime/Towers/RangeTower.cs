using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerDefence.Runtime
{
    public class RangeTower : Tower
    {
        [SerializeField] private int m_enemiesToAttack = default;

        protected override void Attack()
        {
            IEnumerable<IHittable> units = GetUnits(m_enemiesToAttack);
            int unitsCount = units.Count();
            if (unitsCount > 0)
            {
                Debug.Log($"{nameof(RangeTower)}: Attack range of {unitsCount}");
                foreach (IHittable unit in units)
                {
                    unit.Hit(Damage / unitsCount);
                }
                base.Attack();
            }
        }
    }
}
