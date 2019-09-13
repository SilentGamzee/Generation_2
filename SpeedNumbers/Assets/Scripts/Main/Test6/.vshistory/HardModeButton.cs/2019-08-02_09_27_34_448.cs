using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main.Test6
{
    public class HardModeButton : MonoBehaviour
    {
        public float spawn_bonus_time;
        public int wave_countl

        public static float static_spawn_bonus_time = 0;
        void Start()
        {
            this.GetComponent<Button>().onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            static_spawn_bonus_time = spawn_bonus_time;
            PanelManager.Get().city_panel.SetActive(false);
            PanelManager.Get().playground_panel.SetActive(true);
            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
        }
    }
}
