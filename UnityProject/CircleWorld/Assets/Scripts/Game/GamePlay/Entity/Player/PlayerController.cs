using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System;

namespace GameWish.Game
{
    public class PlayerController : EntityController
    {
    
        public static PlayerController Instance = null;

        private PlayerData m_PlayerData = null;
        private PlayerView m_PlayerView = null;
        private PlayerInputMgr m_PlayerInputMgr = null;
        private PlayerRaycast m_PlayerRaycast = null;
        //private PlayerTrailSpawner m_PlayerTrailSpawner = null;
        private PlayerStateMachine m_PlayerStateMachine = null;

        public PlayerData PlayerData
        {
            get { return m_PlayerData; }
        }

        public PlayerView PlayerView
        {
            get { return m_PlayerView; }
        }

        public PlayerStateMachine PlayerStateMachine
        {
            get { return m_PlayerStateMachine; }
        }

        protected override void Init()
        {
            Instance = this;

            m_PlayerData = new PlayerData(this);

            m_PlayerView =  gameObject.AddComponent<PlayerView>();
            m_PlayerView.Init(this);

            m_PlayerInputMgr = gameObject.AddComponent<PlayerInputMgr>();

            m_PlayerRaycast = new PlayerRaycast(this);

            //m_PlayerTrailSpawner = new PlayerTrailSpawner(this);

            m_PlayerStateMachine = new PlayerStateMachine(this);
            m_PlayerStateMachine.SetCurrentStateByID(PlayerStateID.Jump);

            SendEvent(EventID.OnPlayerSpawned, transform);
        }

        public void OnPressedDown()
        {
            m_PlayerData.PlayerSpeedYDecreaseSpeed = m_PlayerData.PlayerSpeedYDecreaseMaxSpeed;
        }

        public void OnPressedUp()
        {
            m_PlayerData.PlayerSpeedYDecreaseSpeed = m_PlayerData.PlayerSpeedYDecreaseNormalSpeed;
        }

        protected override void SetInterestEvent()
        {
            //m_InteresetEvents = new int[] { (int)EventID.OnGetEnergy };
        }

        private void Update()
        {
            if (m_PlayerRaycast != null)
            {
                m_PlayerRaycast.Update();
            }

            UpdateState();

        }

        private void UpdateState()
        {
            if (m_PlayerStateMachine.IsJumping())
            {
                m_PlayerStateMachine.UpdateState(Time.deltaTime);

                //if (m_PlayerRaycast.HasBoardDown)
                //{
                //    SetState(PlayerStateID.Idle);
                //}
            }
        }

        public void OnControlBtnClicked()
        {

        }
        
        public void OnNoControlBtnClicked()
        {

        }

        private void SetState(PlayerStateID state)
        {
            if (m_PlayerStateMachine.currentStateID == state)
                return;

            Log.i("Player change state to : " + state.ToString());

            m_PlayerStateMachine.SetCurrentStateByID(state);
        }

        public override void HandleEvent(int eventId, params object[] param)
        {
            //if (eventId == (int)EventID.OnGetEnergy)
            //{
            //    m_PlayerData.ResetEnergy();
            //}
        }

        public void OnReset(Vector3 pos)
        {
            SetState(PlayerStateID.Idle);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == Define.WORLD_TAG)
            {
                float speedY = Mathf.Min(Mathf.Abs(m_PlayerData.PlayerSpeedY * 0.7f), m_PlayerData.PlayerMaxSpeedY);
                //float speedY = Mathf.Abs(m_PlayerData.PlayerSpeedY);
                m_PlayerData.PlayerSpeedY = speedY;
                m_PlayerData.PlayerSpeedYDecreaseSpeed = m_PlayerData.PlayerSpeedYDecreaseNormalSpeed;
            }
        }
        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.red;
        //    Debug.DrawLine(transform.position, transform.position + new Vector3(0, 0.5f, 0));
        //    Debug.DrawLine(transform.position, transform.position + new Vector3(0, -0.5f, 0));
        //    Debug.DrawLine(transform.position, transform.position + new Vector3(-0.5f, 0, 0));
        //    Debug.DrawLine(transform.position, transform.position + new Vector3(0.5f, 0, 0));
        //}
    }
}
