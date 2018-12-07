using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System;

namespace GameWish.Game
{
    public class WorldControllerBase : EntityController/*, IGameStateObserver*/
    {
        [SerializeField]
        protected GameObject m_WorldBody = null;

        protected WorldData m_WorldData = null;
        protected WorldView m_WorldView = null;

        protected override void Init()
        {
            m_WorldData = new WorldData(this);
            m_WorldView = gameObject.AddComponent<WorldView>();
        }

        protected override void SetInterestEvent()
        {
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            
        }
    }
}
