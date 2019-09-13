using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.Test6
{
    public class BulletObject : MonoBehaviour
    {
        public static int kill_count = 0;
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "top")
                Destroy(this.gameObject);
            else if (collision.gameObject.tag == "enemy")
            {
                MoveCoordinator.P += (1 + PlayerManager.player_training_lvl) * HardModeButton.static_mode_coins_mult;
                kill_count++;
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
                GameEndManager.OnWaveCounter();
                if (kill_count >= HardModeButton.static_wave_count)
                    GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
            }
        }

        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving)
            {
                Destroy(this.gameObject);
                return;
            }
            transform.Translate(0, Time.deltaTime * 2f * (1 + PlayerManager.player_speed_lvl), 0);
        }
    }
}
