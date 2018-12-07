﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System;

namespace GameWish.Game
{
    public class PlayerData : EntityData
    {
        private PlayerController m_PlayerController = null;

        private float m_PlayerNormalSpeedX = -4f;
        private float m_PlayerMaxSpeedX = -5f;
        private float m_PlayerSpeedX;
        private float m_PlayerSpeedY;
        private float m_PlayerSpeedYDecreaseSpeed;
        private float m_PlayerSpeedYDecreaseNormalSpeed = 3f;
        private float m_PlayerSpeedYDecreaseMaxSpeed = 30f;
        private float m_PlayerMaxSpeedY = 5f;
        private float m_PlayerNormalSpeedY = 3f;
        private float m_PlayerHitGroundMinSpeedY = 1f;
        private float m_GravityDir = 1f;

        private Vector3? m_MoveDir = null;

        public float PlayerSpeedX
        {
            set { m_PlayerSpeedX = value; }
            get { return m_PlayerSpeedX; }
        }

        public float PlayerSpeedY
        {
            set { m_PlayerSpeedY = value; }
            get { return m_PlayerSpeedY; }
        }

        public float PlayerMaxSpeedY
        {
            get { return m_PlayerMaxSpeedY; }
        }

        public float PlayerSpeedYDecreaseSpeed
        {
            set { m_PlayerSpeedYDecreaseSpeed = value; }
            get { return m_PlayerSpeedYDecreaseSpeed; }
        }

        public float PlayerSpeedYDecreaseMaxSpeed
        {
            get { return m_PlayerSpeedYDecreaseMaxSpeed; }
        }

        public float PlayerSpeedYDecreaseNormalSpeed
        {
            get { return m_PlayerSpeedYDecreaseNormalSpeed; }
        }

        public float PlayerHitGroundMinSpeedY
        {
            get { return m_PlayerHitGroundMinSpeedY; }
        }

        public float PlayerNormalSpeedX
        {
            get { return m_PlayerNormalSpeedX; }
        }

        public float PlayerMaxSpeedX
        {
            get { return m_PlayerMaxSpeedX; }
        }

        public Vector3 MoveDir
        {
            set { m_MoveDir = value; }
            get { return m_MoveDir.Value; }
        }

        public float GravityDir
        {
            set { m_GravityDir = value; }
            get { return m_GravityDir; }
        }

        public PlayerData(PlayerController controller) : base(controller)
        {
            m_PlayerController = controller;

            m_PlayerSpeedYDecreaseSpeed = m_PlayerSpeedYDecreaseNormalSpeed;
            m_PlayerSpeedY = m_PlayerNormalSpeedY;
            m_PlayerSpeedX = m_PlayerNormalSpeedX;
        }
    }
}
