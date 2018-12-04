using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System;

namespace GameWish.Game
{
    public class PlayerView : EntityView
    {
        private PlayerController m_PlayerController = null;
        public void Init(PlayerController playerController)
        {
            m_PlayerController = playerController;
        }

        private void RotateToDir(Vector3 dir, Transform body)
        {
            Vector3 forward = body.up;
            Vector3 toTargetDir = dir;
            Quaternion toTargetDirQuaternion = Quaternion.FromToRotation(forward, toTargetDir);
            body.rotation *= toTargetDirQuaternion;
        }

        private void Update()
        {
            Vector3 dir = m_PlayerController.transform.position - WorldsMgr.S.CurWorld.transform.position;
            RotateToDir(dir, m_PlayerController.transform);
        }
    }
}
