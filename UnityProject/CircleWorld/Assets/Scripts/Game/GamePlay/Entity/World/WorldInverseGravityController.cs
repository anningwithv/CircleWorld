using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System;

namespace GameWish.Game
{
    public class WorldInverseGravityController : WorldControllerBase/*, IGameStateObserver*/
    {
        private void Update()
        {

        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            if (collision.tag == Define.PLAYER_TAG)
            {
                SendEvent(EventID.OnSetGravityInversed);
            }
        }
    }
}
