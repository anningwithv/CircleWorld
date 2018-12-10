using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Qarth;

namespace GameWish.Game
{
    public class MainGamePanel : AbstractPanel
    {
        [SerializeField]
        private Image m_EnergyProgressBar = null;
        [SerializeField]
        private Image m_WorldProgressBar = null;

        protected override void OnPanelOpen(params object[] args)
        {

        }

        protected override void OnUIInit()
        {
            Init();
        }

        private void Init()
        {
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            EventSystem.S.Register((int)EventID.OnPlayerEnergyChanged, HandleEvent);
            EventSystem.S.Register((int)EventID.OnWorldHpChanged, HandleEvent);
        }

        private void HandleEvent(int eventId, params object[] param)
        {
            if (eventId == (int)EventID.OnPlayerEnergyChanged)
            {
                float percent = (float)param[0];
                UpdateEnergyHpProgress(percent);
            }
            else if (eventId == (int)EventID.OnWorldHpChanged)
            {
                float percent = (float)param[0];
                UpdateWorldHpProgress(percent);
            }
        }

        private void UpdateEnergyHpProgress(float percent)
        {
            Log.i("Energy percent is: " + percent);
            m_EnergyProgressBar.fillAmount = percent;
        }

        private void UpdateWorldHpProgress(float percent)
        {
            Log.i("World hp percent is: " + percent);
            m_WorldProgressBar.fillAmount = percent;
        }
    }
}
