using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System;
using DG.Tweening;

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

        public void OnPressYDown()
        {
            transform.DOScale(new Vector3(0.8f, 0.8f, 1f), 0.2f);
            m_PlayerData.PlayerSpeedYDecreaseSpeed = m_PlayerData.PlayerSpeedYDecreaseMaxSpeed;
        }

        public void OnPressedYUp()
        {
            transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
            m_PlayerData.PlayerSpeedYDecreaseSpeed = m_PlayerData.PlayerSpeedYDecreaseNormalSpeed;
        }

        public void OnPressXDown()
        {
            if (!HasEnergy())
                return;

            m_PlayerData.PlayerSpeedX = m_PlayerData.PlayerMaxSpeedX;

            m_PlayerStateMachine.SetCurrentStateByID(PlayerStateID.Dash);
        }

        public void OnPressedXUp()
        {
            //m_PlayerData.PlayerSpeedX = m_PlayerData.PlayerNormalSpeedX;

            m_PlayerStateMachine.SetCurrentStateByID(PlayerStateID.Jump);
        }

        protected override void SetInterestEvent()
        {
            m_InteresetEvents = new int[] { (int)EventID.OnPlayerHurt,
            (int)EventID.OnSetGravityInversed, (int)EventID.OnPlayerGetEnergy};
        }

        private void Update()
        {
            if (m_PlayerRaycast != null)
            {
                m_PlayerRaycast.Update();
            }

            UpdateState();

            //Log.i("Current state id is: " + m_PlayerStateMachine.currentStateID.ToString());
        }

        private void UpdateState()
        {
            if (m_PlayerStateMachine.IsJumping())
            {
                m_PlayerStateMachine.UpdateState(Time.deltaTime);
            }
            else if (m_PlayerStateMachine.IsDashing())
            {
                bool hasEnergy = UpdateEnergy();
                if (!hasEnergy)
                {
                    m_PlayerStateMachine.SetCurrentStateByID(PlayerStateID.Jump);
                }
                else
                {
                    m_PlayerStateMachine.UpdateState(Time.deltaTime);
                }
            }
        }

        private bool HasEnergy()
        {
            bool hasEnergy = m_PlayerData.Energy > 0;
            Log.i("Player has energy : " + hasEnergy);
            return hasEnergy;
        }

        private bool UpdateEnergy()
        {
            m_PlayerData.Energy -= m_PlayerData.EnergyDecreaseSpeed * Time.deltaTime;
            if (m_PlayerData.Energy > 0)
            {
                return true;
            }
            else
            {
                m_PlayerData.Energy = 0;
                return false;
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
            if (eventId == (int)EventID.OnPlayerHurt)
            {
                GameStateMgr.S.EndGame();
            }
            else if (eventId == (int)EventID.OnSetGravityInversed)
            {
                m_PlayerData.GravityDir *= -1;
            }
            else if (eventId == (int)EventID.OnPlayerGetEnergy)
            {
                float value = (float)param[0];
                m_PlayerData.Energy += value;
            }
        }

        public void OnReset(Vector3 pos)
        {
            SetState(PlayerStateID.Idle);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == Define.WORLD_TAG)
            {
                // Calculate damage by speed
                WorldsMgr.S.CurWorld.HitByPlayer(10);

                // reset speed
                float speedY = Mathf.Min(Mathf.Abs(m_PlayerData.PlayerSpeedY * 0.7f), m_PlayerData.PlayerMaxSpeedY);
                speedY = Mathf.Max(m_PlayerData.PlayerHitGroundMinSpeedY, speedY);
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
