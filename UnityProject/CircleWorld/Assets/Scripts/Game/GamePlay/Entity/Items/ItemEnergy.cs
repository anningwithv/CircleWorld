using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameWish.Game
{
    public class ItemEnergy : ItemBase
    {
        protected override void Init()
        {
        }

        protected override void SetInterestEvent()
        {
        }

        public override void OnColliderPlayer()
        {
            SendEvent(EventID.OnPlayerGetEnergy, 1f);
            base.OnColliderPlayer();
        }
    }
}