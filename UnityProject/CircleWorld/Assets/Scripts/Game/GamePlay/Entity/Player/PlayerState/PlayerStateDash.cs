using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public class PlayerStateDash : PlayerState
    {
        public PlayerStateDash(PlayerStateID stateEnum) : base(stateEnum)
        {
        }

        public override void Enter(PlayerController mgr)
        {

        }

        public override void Exit(PlayerController mgr)
        {
        }

        public override void Execute(PlayerController mgr, float dt)
        {
            Vector3 speedYDir = mgr.PlayerData.GravityDir * (mgr.transform.position - WorldsMgr.S.CurWorld.transform.position).normalized;
            Vector3 speedXDir = Vector3.Cross(Vector3.forward, speedYDir).normalized;

            mgr.PlayerData.PlayerSpeedY = 0;

            Vector3 moveSpeed = speedYDir * mgr.PlayerData.PlayerSpeedY + speedXDir * mgr.PlayerData.PlayerSpeedX;
            mgr.PlayerData.MoveDir = moveSpeed.normalized;

            mgr.transform.position += moveSpeed * Time.deltaTime;
        }

        //private void HandlePlayerOutOfRange(PlayerController mgr)
        //{
        //    bool isOutOfRange = IsPlayerOutOfCameraRange(mgr);
        //    if (isOutOfRange)
        //    {
        //        Debug.Log("Player is out of range");
        //        if (mgr.transform.position.x < 0)
        //        {
        //            mgr.transform.position += new Vector3(Define.WORLD_WIDTH, 0, 0);
        //        }
        //        else if (mgr.transform.position.x > 0)
        //        {
        //            mgr.transform.position -= new Vector3(Define.WORLD_WIDTH, 0, 0);
        //        }
        //    }
        //}

        //private bool IsPlayerOutOfCameraRange(PlayerController mgr)
        //{
        //    float posX = mgr.transform.position.x;
        //    if ((posX >= Define.WORLD_WIDTH * 1.0f / 2 && mgr.PlayerData.CurMoveSpdX > 0) ||
        //        (posX <= -Define.WORLD_WIDTH * 1.0f / 2 && mgr.PlayerData.CurMoveSpdX < 0))
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //private void Move(PlayerController mgr)
        //{
        //    mgr.PlayerData.UpdateSpeedWhenMove();

        //    Vector3 deltaPos = new Vector3(mgr.PlayerData.CurMoveSpdX * Time.deltaTime, mgr.PlayerData.CurMoveSpdY * Time.deltaTime, 0);
        //    mgr.transform.position += deltaPos;
        //    mgr.PlayerData.CurMoveDistance += deltaPos.magnitude;
        //}

    }
}
