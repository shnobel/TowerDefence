using System.Collections;
using TowerDefense.Runtime;
using UnityEngine;
using Zenject;

namespace TowerDefence.Runtime
{
    public class MoveModel : MonoBehaviour, IMovable
    {
        [SerializeField]
        private float m_speed = 1f;
        [SerializeField]
        private Path m_path = default;

        private Vector3 m_start = default;
        private Vector3 m_end = default;
        private float m_interpolate = 0f;
        private int m_pathIndex = 0;
        protected Level m_level = default;

        protected bool IsMoving { get; private set; }

        [Inject]
        public void Construct(Level level)
        {
            m_level = level;
        }


        protected virtual void Start()
        {
            StartCoroutine(Move());
        }

        void IMovable.Move()
        {
            m_start = transform.position;
            m_end = m_path.GetPoint(m_pathIndex).position;
            IsMoving = true;
            StartCoroutine(Move());
        }

        protected virtual IEnumerator Move()
        {
            while (true)
            {
                m_interpolate += Time.deltaTime * m_speed / Vector3.Distance(m_start, m_end);
                transform.position = Vector3.Lerp(m_start, m_end, m_interpolate);
                transform.LookAt(m_end);
                if (m_interpolate >= 1)
                {
                    m_pathIndex++;
                    if (m_pathIndex >= m_path.Length)
                    {
                        m_pathIndex = 0;
                        IsMoving = false;
                    }

                    m_start = transform.position;
                    m_end = m_path.GetPoint(m_pathIndex).position;
                    m_interpolate = 0;
                }
                yield return null;
            }
        }
    }
}
