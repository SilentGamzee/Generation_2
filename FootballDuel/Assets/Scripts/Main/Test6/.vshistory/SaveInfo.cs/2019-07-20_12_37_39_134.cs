﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.Test6
{
    public class SaveInfo : MonoBehaviour
    {


        public int upgrade_1_lvl;
        public int upgrade_2_lvl;
        public int upgrade_3_lvl;


        public static void OnStart()
        {
            if (!PlayerPrefs.HasKey("money")) return;

            PlayerManager.Points = PlayerPrefs.GetInt("money", 0);
            PlayerManager.level = PlayerPrefs.GetInt("level", 0);
            PlayerManager.EXP = PlayerPrefs.GetInt("exp", 0);
            Debug.Log(ButtonListener._instance.buildings[0].GetComponent<BuildingObject>().building_lvl);
            ButtonListener._instance.buildings[0].GetComponent<BuildingObject>().building_lvl
                 = PlayerPrefs.GetInt("building_1", 0);
            ButtonListener._instance.buildings[1].GetComponent<BuildingObject>().building_lvl
                = PlayerPrefs.GetInt("building_2", 0);
            ButtonListener._instance.buildings[2].GetComponent<BuildingObject>().building_lvl
                = PlayerPrefs.GetInt("building_3", 0);
            var upgrade_1_lvl = PlayerPrefs.GetInt("upgrade_1", 0);
            for (var i = 0; i < upgrade_1_lvl; i++)
                ButtonListener._instance.upgrades[0].OnUpgrade(false);

            var upgrade_2_lvl = PlayerPrefs.GetInt("upgrade_2", 0);
            for (var i = 0; i < upgrade_2_lvl; i++)
                ButtonListener._instance.upgrades[1].OnUpgrade(false);

            var upgrade_3_lvl = PlayerPrefs.GetInt("upgrade_3", 0);
            for (var i = 0; i < upgrade_3_lvl; i++)
                ButtonListener._instance.upgrades[2].OnUpgrade(false);
        }

        public static void OnSave()
        {
            PlayerPrefs.SetInt("money", PlayerManager.Points);
            PlayerPrefs.SetInt("level", PlayerManager.level);
            PlayerPrefs.SetInt("exp", PlayerManager.EXP);
            PlayerPrefs.SetInt("building_1", ButtonListener._instance.buildings[0].GetComponent<BuildingObject>().building_lvl);
            PlayerPrefs.SetInt("building_2", ButtonListener._instance.buildings[1].GetComponent<BuildingObject>().building_lvl);
            PlayerPrefs.SetInt("building_3", ButtonListener._instance.buildings[2].GetComponent<BuildingObject>().building_lvl);
            PlayerPrefs.SetInt("upgrade_1", PlayerManager.player_speed_lvl);
            PlayerPrefs.SetInt("upgrade_2", PlayerManager.player_switch_lvl);
            PlayerPrefs.SetInt("upgrade_3", PlayerManager.player_training_lvl);
        }
    }
}
