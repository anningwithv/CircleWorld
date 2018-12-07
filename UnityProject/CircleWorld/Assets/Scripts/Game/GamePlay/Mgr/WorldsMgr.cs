using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;

namespace GameWish.Game
{
    public class WorldsMgr : TSingleton<WorldsMgr>,IGameStateObserver
    {
        private WorldControllerBase m_InitWorld = null;
        private WorldControllerBase m_CurWorld = null;
        private ResLoader m_PlayerLoader = null;
        private Vector3 m_PlayerSpawnPos = new Vector3(0,4,0);
        private PlayerController m_PlayerController = null;

        public WorldControllerBase CurWorld
        {
            get { return m_CurWorld; }
            set
            {
                if (m_CurWorld != value)
                {
                    m_CurWorld = value;
                    EventSystem.S.Send(EventID.OnCurWorldChanged);
                }
            }
        }

        public void Init(WorldControllerBase world)
        {
            GameStateMgr.S.AddObserver(this);

            m_PlayerLoader = ResLoader.Allocate("PlayerLoader");

            m_CurWorld = world;
            m_InitWorld = world;

            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            GameObject playerPrefab = m_PlayerLoader.LoadSync(Define.PLAYER_PREFAB) as GameObject;
            var playerObj = GameObject.Instantiate(playerPrefab) as GameObject;

            playerObj.transform.position = m_PlayerSpawnPos;

            m_PlayerController = playerObj.GetComponent<PlayerController>();
        }

        #region IGameStateObserver
        public void OnGameStart()
        {
        }

        public void OnGamePlaying()
        {
        }

        public void OnGamePaused()
        {
        }

        public void OnGameResumed()
        {
        }

        public void OnGameOver()
        {
        }

        public void OnGameRestarted()
        {
            m_PlayerController.transform.position = m_PlayerSpawnPos;
            CurWorld = m_InitWorld;
        }
        #endregion
    }
}