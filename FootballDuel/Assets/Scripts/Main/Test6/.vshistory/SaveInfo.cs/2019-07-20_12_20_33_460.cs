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

      
        public int upgrade_1_lvl;
        public int upgrade_2_lvl;
        public int upgrade_3_lvl;


        public static void OnStart()
        {
            if (!PlayerPrefs.HasKey("money")) return;

            PlayerManager.Points = PlayerPrefs.GetInt("money", 0);
            PlayerManager.level = PlayerPrefs.GetInt("level", 0);
            ButtonListener._instance.buildings[0].GetComponent<BuildingObject>().building_lvl
                 = PlayerPrefs.GetInt("building_1", 0);
            ButtonListener._instance.buildings[1].GetComponent<BuildingObject>().building_lvl
                = PlayerPrefs.GetInt("building_2", 0);
            ButtonListener._instance.buildings[2].GetComponent<BuildingObject>().building_lvl
                = PlayerPrefs.GetInt("building_3", 0);

        }
    }
}
