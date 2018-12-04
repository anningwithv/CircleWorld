using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System;

namespace GameWish.Game
{
    public class PlayerRaycast
    {
        private PlayerController m_PlayerController = null;

        private float m_BodyHeight = 0.6f;
        private float m_BodyWidth = 0.4f;
        private int m_IgnoreLayerMask = ~(1<<LayerMask.NameToLayer(Define.PLAYER_LAYER));

        private bool m_HasBoardBottom = false;
        private RaycastHit2D m_RaycastHitBottom;

        private Vector2 m_RaycastOriginPos;

        public bool HasBoardDown
        {
            get { return m_HasBoardBottom; }
        }

        public PlayerRaycast(PlayerController playerController)
        {
            m_PlayerController = playerController;
        }

        public void Update()
        {
            m_RaycastOriginPos = new Vector2(m_PlayerController.transform.position.x, m_PlayerController.transform.position.y);

            RaycastToBottom();
        }

        private void RaycastToBottom()
        {
            m_HasBoardBottom = Raycast(Vector2.down, m_BodyHeight / 2f, out m_RaycastHitBottom);
        }

        private bool Raycast(Vector2 dir, float distance, out RaycastHit2D raycastHit2D)
        {
            raycastHit2D = Physics2D.Raycast(m_RaycastOriginPos, dir, distance, m_IgnoreLayerMask);

            if (raycastHit2D.transform != null)
            {
                if(raycastHit2D.transform.GetComponent<BoardBaseController>()!= null)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
