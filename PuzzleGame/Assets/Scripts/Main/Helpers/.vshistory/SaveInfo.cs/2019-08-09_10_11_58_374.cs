using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.Test6
{
    public class SaveInfo : MonoBehaviour
    {
        public static void OnStart()
        {
            //PlayerPrefs.DeleteAll();
            if (!PlayerPrefs.HasKey("money")) return;

            PlayerManager.Points = PlayerPrefs.GetInt("money", 0);
            Debug.Log(PlayerPrefs.GetInt("money", 0) + "");

            PlayerManager.player_speed_lvl = PlayerPrefs.GetInt("upgrade_1", 0);
            PlayerManager.player_switch_lvl = PlayerPrefs.GetInt("upgrade_2", 0);
            PlayerManager.player_training_lvl = PlayerPrefs.GetInt("upgrade_3", 0);
        }

        public static void OnSave()
        {
            PlayerPrefs.SetInt("money", PlayerManager.Points);

            if (PlayerManager.player_speed_lvl != 0)
                PlayerPrefs.SetInt("upgrade_1", PlayerManager.player_speed_lvl);
            if (PlayerManager.player_switch_lvl != 0)
                PlayerPrefs.SetInt("upgrade_2", PlayerManager.player_switch_lvl);
            if (PlayerManager.player_training_lvl != 0)
                PlayerPrefs.SetInt("upgrade_3", PlayerManager.player_training_lvl);
            PlayerPrefs.Save();
        }
    }
}
