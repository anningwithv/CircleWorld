using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System;

namespace GameWish.Game
{
    public class GravityRange : MonoBehaviour
    {
        private WorldController m_World = null;

        private void Awake()
        {
            m_World = GetComponentInParent<WorldController>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == Define.PLAYER_TAG)
            {
                bool isAlreadyCurWorld = WorldsMgr.S.CurWorld == m_World;
                if (isAlreadyCurWorld == false && m_World != null)
                {
                    WorldsMgr.S.CurWorld = m_World;
                }
            }
        }
    }
}
