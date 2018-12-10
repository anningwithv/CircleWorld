using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using DG.Tweening;

namespace GameWish.Game
{
    public class WorldsMgr : TSingleton<WorldsMgr>,IGameStateObserver
    {
        private WorldControllerBase m_InitWorld = null;
        private WorldControllerBase m_CurWorld = null;
        private ResLoader m_PlayerLoader = null;
        private ResLoader m_WorldLoader = null;
        private Vector3 m_PlayerSpawnPos = new Vector3(0,4,0);
        private Vector3 m_NewWorldSpawnPos = new Vector3(0, 0, 30);
        private PlayerController m_PlayerController = null;

        public WorldControllerBase CurWorld
        {
            get { return m_CurWorld; }
            set
            {
                if (m_CurWorld != value)
                {
                    m_CurWorld = value;
                    //EventSystem.S.Send(EventID.OnCurWorldChanged);
                }
            }
        }

        public void Init(WorldControllerBase world)
        {
            GameStateMgr.S.AddObserver(this);

            RegisterEvents();

            m_PlayerLoader = ResLoader.Allocate("PlayerLoader");
            m_WorldLoader = ResLoader.Allocate("WorldLoader");

            m_CurWorld = world;
            m_InitWorld = world;

            SpawnPlayer();
        }

        private void RegisterEvents()
        {
            EventSystem.S.Register(EventID.OnWorldDestroyed, HandleEvent);
        }

        private void HandleEvent(int eventId, params object[] param)
        {
            if(eventId == (int)EventID.OnWorldDestroyed)
            {
                SpawnNewWorld();
            }
        }

        private void SpawnNewWorld()
        {
            Log.i("Spawn new world");

            GameObject newWorldPrefab = m_WorldLoader.LoadSync("World1") as GameObject;
            var newWorldObj = GameObject.Instantiate(newWorldPrefab) as GameObject;

            newWorldObj.transform.position = m_NewWorldSpawnPos;
            WorldControllerBase newWorldController = newWorldObj.GetComponent<WorldControllerBase>();

            m_CurWorld.HideBody();

            GameObject oldWorld = m_CurWorld.gameObject;
            m_CurWorld = newWorldController;

            m_PlayerController.gameObject.SetActive(false);

            oldWorld.transform.DOMoveZ(-30, 5.0f).SetRelative().OnComplete(()=> {
                GameObject.Destroy(oldWorld);
            });
            //m_ = playerObj.GetComponent<PlayerController>();
            m_CurWorld.transform.DOMoveZ(-30, 5.0f).SetRelative().OnComplete(()=> {
                m_PlayerController.gameObject.SetActive(true);
            });
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