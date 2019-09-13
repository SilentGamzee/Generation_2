using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.Test6
{
    public class SaveInfo:MonoBehaviour
    {
       
        public int building_1_lvl;
        public int building_2_lvl;
        public int building_3_lvl;
        public int upgrade_1_lvl;
        public int upgrade_2_lvl;
        public int upgrade_3_lvl;


        public static void OnStart()
        {
           PlayerManager.Points = PlayerPrefs.GetInt("money", 0);
            PlayerPrefs.GetInt("building_1", 0);
        }
    }
}
