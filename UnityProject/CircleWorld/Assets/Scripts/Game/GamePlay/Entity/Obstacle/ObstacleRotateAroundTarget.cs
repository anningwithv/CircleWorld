using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameWish.Game
{
    public class ObstacleRotateAroundTarget : ObstacleBase
    {
        [SerializeField]
        private Transform m_Target = null;

        [SerializeField]
        private float m_RotateSpeed = 1;

        private float m_ToTargetDistance;

        private void Start()
        {
            m_ToTargetDistance = Vector3.Distance(transform.position, m_Target.position);
        }

        private void Update()
        {
            transform.RotateAround(m_Target.position, m_Target.forward, m_RotateSpeed * Time.deltaTime);
        }
    }
}
