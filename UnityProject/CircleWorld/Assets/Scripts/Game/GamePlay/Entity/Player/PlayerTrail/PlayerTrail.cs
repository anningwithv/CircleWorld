using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Qarth;

namespace GameWish.Game
{
    public class PlayerTrail : PoolObjectComponent
    {
        private float m_TotalMoveTime = 0.3f;
        private float m_MoveTime = 0f;
        private float m_MoveSpeed = 5f;
        private bool m_Move = false;

        private void Update()
        {

        }

        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.gameObject.GetComponent<BoardBaseController>() != null)
        //    {
        //        StartCoroutine(RecycleCor());
        //    }
        //}

        //private IEnumerator RecycleCor()
        //{
        //    yield return null;
        //    GameObjectPoolMgr.S.Recycle(gameObject);
        //}

        //public override void OnReset2Cache()
        //{
        //    m_Move = false;
        //    m_MoveTime = 0;
        //}
    }
}
