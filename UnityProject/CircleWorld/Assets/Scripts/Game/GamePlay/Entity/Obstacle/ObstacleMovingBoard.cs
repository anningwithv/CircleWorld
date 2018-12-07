using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GameWish.Game
{
    public class ObstacleMovingBoard : ObstacleBase
    {
        public enum MoveDir
        {
            x,
            y
        }

        [SerializeField]
        private float m_MovingSpeed = 1;
        [SerializeField]
        private float m_MovingDistance = 1;
        [SerializeField]
        private MoveDir m_MovingDir = MoveDir.y;

        private void Start()
        {
            if (m_MovingDir == MoveDir.x)
            {
                Sequence seq = DOTween.Sequence();
                seq.Append(transform.DOLocalMoveX(m_MovingDistance, m_MovingDistance / m_MovingSpeed).SetRelative());
                seq.Append(transform.DOLocalMoveX(-m_MovingDistance, m_MovingDistance / m_MovingSpeed).SetRelative());
                seq.SetLoops(-1);
            }
            else if (m_MovingDir == MoveDir.y)
            {
                Sequence seq = DOTween.Sequence();
                seq.Append(transform.DOLocalMoveY(m_MovingDistance, m_MovingDistance / m_MovingSpeed).SetRelative());
                seq.Append(transform.DOLocalMoveY(-m_MovingDistance, m_MovingDistance / m_MovingSpeed).SetRelative());
                seq.SetLoops(-1);
            }
        }
    }
}
