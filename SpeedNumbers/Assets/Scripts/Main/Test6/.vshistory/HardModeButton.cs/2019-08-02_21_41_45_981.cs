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
        public float bonus_time;
        

        public static float static_bonus_time = 0;
        
        void Start()
        {
            this.GetComponent<Button>().onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            static_bonus_time = bonus_time;
            static_wave_count = wave_count;
            static_mode_coins_mult = coins_mult;
            EnemySpawner.spawn_count = 0;
            BulletObject.kill_count = 0;
            GameEndManager.OnWaveCounter();
            PanelManager.Get().city_panel.SetActive(false);
            PanelManager.Get().playground_panel.SetActive(true);
            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
        }
    }
}
