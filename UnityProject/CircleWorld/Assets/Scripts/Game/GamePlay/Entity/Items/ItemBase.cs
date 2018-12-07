﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameWish.Game
{
    public class ItemBase : EntityController, IItem
    {
        protected override void Init()
        {
        }

        protected override void SetInterestEvent()
        {
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == Define.PLAYER_TAG)
            {
                OnColliderPlayer();
            }
        }

        public virtual void OnColliderPlayer()
        {
            Destroy(gameObject);
        }
    }
}