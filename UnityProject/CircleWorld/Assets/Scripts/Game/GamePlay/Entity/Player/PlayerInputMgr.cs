﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System;

namespace GameWish.Game
{
    using HedgehogTeam.EasyTouch;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerInputMgr : MonoBehaviour, IInputObserver
    {
        private PlayerController m_PlayerController = null;

        private bool m_CanHandleInput = false;

        private void Start()
        {
            InputMgr.S.AddTouchObserver(this);

            m_PlayerController = GetComponent<PlayerController>();
        }

        private void Update()
        {

        }

        public void On_LongTap(Gesture gesture)
        {
        }

        public void On_TouchStart(Gesture gesture)
        {
        }

        public void On_TouchDown(Gesture gesture)
        {
            
        }

        public void On_TouchUp(Gesture gesture)
        {
        }

        public void On_Drag(Gesture gesture, bool isTouchStartFromUI)
        {
        }

        public void On_Swipe(Gesture gesture)
        {

        }
    }
}