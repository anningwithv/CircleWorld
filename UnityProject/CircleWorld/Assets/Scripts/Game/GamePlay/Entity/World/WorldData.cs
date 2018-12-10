using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System;

namespace GameWish.Game
{
    public class WorldData : EntityData
    {
        private WorldControllerBase m_WorldController = null;

        private float m_InitWorldHP = 100f;
        private float m_WorldHP;

        public WorldData(WorldControllerBase controller) : base(controller)
        {
            m_WorldController = controller;

            m_WorldHP = m_InitWorldHP;

            EventSystem.S.Send(EventID.OnWorldHpChanged, m_WorldHP / m_InitWorldHP);
        }

        public float WorldHP
        {
            set
            {
                value = Mathf.Clamp(value, 0, m_InitWorldHP);
                if (m_WorldHP != value)
                { 
                    m_WorldHP = value;
                    EventSystem.S.Send(EventID.OnWorldHpChanged, m_WorldHP / m_InitWorldHP);

                    if (value <= 0)
                    {
                        EventSystem.S.Send(EventID.OnWorldDestroyed);
                    }
                }
            }
            get { return m_WorldHP; }
        }
    }
}
