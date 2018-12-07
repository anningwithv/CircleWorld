using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System;

namespace GameWish.Game
{
    public class WorldView : EntityView
    {
        private WorldControllerBase m_WorldController = null;

        public void Init(WorldControllerBase worldController)
        {
            m_WorldController = worldController;
        }

        private void Rotate()
        {

        }
    }
}
