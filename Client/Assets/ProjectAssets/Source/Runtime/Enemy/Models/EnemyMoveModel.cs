using UnityEngine;

namespace TowerDefence.Runtime
{
    public sealed class EnemyMoveModel : MoveModel
    {
        protected override void Start()
        {
            Debug.LogWarning($"{nameof(EnemyMoveModel)}: I was created.");
            base.Start();
        }

        private void Update()
        {
            if (!IsMoving)
            {
                //m_level.Decrease();
                Destroy(gameObject);
            }
        }
    }
}
