using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System;

namespace GameWish.Game
{
    public class PlayerData : EntityData
    {
        private PlayerController m_PlayerController = null;

        private float m_PlayerJumpHorizontalSpeed = 5f;
        private float m_PlayerJumpVerticalSpeed = 5f;
        private float m_PlayerFallSpeed = 4f;

        public float PlayerJumpHorizontalSpeed
        {
            get { return m_PlayerJumpHorizontalSpeed; }
        }

        public float PlayerJumpVerticalSpeed
        {
            get { return m_PlayerJumpVerticalSpeed; }
        }

        public float PlayerFallSpeed
        {
            get { return m_PlayerFallSpeed; }
        }

        public PlayerData(PlayerController controller) : base(controller)
        {
            m_PlayerController = controller;

        }
    }
}
