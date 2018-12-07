using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System;

namespace GameWish.Game
{
    public class WorldRotateController : WorldControllerBase/*, IGameStateObserver*/
    {
        [SerializeField]
        private float m_RotateSpeed = 5f;

        private void Update()
        {
            if (m_WorldBody == null)
                return;

            m_WorldBody.transform.localEulerAngles = new Vector3(0, 0, m_WorldBody.transform.localEulerAngles.z + m_RotateSpeed * Time.deltaTime);
        }
    }
}
