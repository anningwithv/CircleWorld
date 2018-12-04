using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System;

namespace GameWish.Game
{
    public class WorldController : EntityController/*, IGameStateObserver*/
    {

        private WorldData m_WorldData = null;
        private WorldView m_WorldView = null;

        private ResLoader m_WorldLoader = null;

        private PlayerController m_PlayerController = null;

        protected override void Init()
        {
            //GameStateMgr.S.AddObserver(this);

            m_WorldData = new WorldData(this);
            m_WorldView = gameObject.AddComponent<WorldView>();

            m_WorldLoader = ResLoader.Allocate("WorldLoader");
        }

        private void Start()
        {
            //SpawnGameObjs();

            //gameObject.AddComponent<PatternController>();
        }

        //private void SpawnGameObjs()
        //{
        //    SpawnPlayer();
        //}

        protected override void SetInterestEvent()
        {
        }
    }
}
