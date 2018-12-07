using System.Collections;
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
            if (Input.GetKeyDown(KeyCode.S))
            {
                m_PlayerController.OnPressYDown();
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                m_PlayerController.OnPressedYUp();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                m_PlayerController.OnPressXDown();
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                m_PlayerController.OnPressedXUp();
            }
        }

        public void On_LongTap(Gesture gesture)
        {
        }

        public void On_TouchStart(Gesture gesture)
        {
            //m_PlayerController.OnPressedDown();
        }

        public void On_TouchDown(Gesture gesture)
        {
            
        }

        public void On_TouchUp(Gesture gesture)
        {
            //m_PlayerController.OnPressedUp();
        }

        public void On_Drag(Gesture gesture, bool isTouchStartFromUI)
        {
        }

        public void On_Swipe(Gesture gesture)
        {

        }
    }
}
