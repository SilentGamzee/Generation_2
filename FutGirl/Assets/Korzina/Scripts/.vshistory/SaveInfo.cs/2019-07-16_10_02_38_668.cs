using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Korzina.Scripts
{

    public class SaveInfo
    {
        public static List<int> upgrades = new List<int>();
        public static int Goals = 0;

        public static void Start()
        {
            for (var i = 0; i < 10; i++)
                if (PlayerPrefs.HasKey("upgrade_" + i))
                {
                    Debug.Log(i+" "+PlayerPrefs.GetInt("upgrade_" + i));
                    upgrades[i] = PlayerPrefs.GetInt("upgrade_" + i);
                }
            if (PlayerPrefs.HasKey("Goals"))
                PlayerManager._instance.goals = PlayerPrefs.GetInt("Goals");
        }

        public static void End()
        {
            for (var i = 0; i < upgrades.Count; i++)
                PlayerPrefs.SetInt("upgrade_" + i, upgrades[i]);

            PlayerPrefs.SetInt("Goals", Goals);
        }
    }
}
