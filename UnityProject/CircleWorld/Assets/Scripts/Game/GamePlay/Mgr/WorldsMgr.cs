using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;

namespace GameWish.Game
{
    public class WorldsMgr : TSingleton<WorldsMgr>,IGameStateObserver
    {
        private WorldController m_CurWorld = null;

        public WorldController CurWorld
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

        public void Init(WorldController world)
        {
            GameStateMgr.S.AddObserver(this);

            m_CurWorld = world;
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

        }
        #endregion
    }
}