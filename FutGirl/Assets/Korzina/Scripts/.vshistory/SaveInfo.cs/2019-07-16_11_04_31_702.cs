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

        public static List<int> openedIndexes = new List<int>();

        public static void Start()
        {
            upgrades.Clear();
            for (var i = 0; i < 10; i++)
                if (PlayerPrefs.HasKey("upgrade_" + i))
                    upgrades.Add(PlayerPrefs.GetInt("upgrade_" + i));

            var manager = PlayerManager._instance;
            for (var i = 0; i < manager.Tiers_count * manager.Girls_count * manager.Poses_count; i++)
                if (PlayerPrefs.HasKey("index_" + i))
                    upgrades.Add(PlayerPrefs.GetInt("index_" + i));

            if (PlayerPrefs.HasKey("Goals"))
                PlayerManager._instance.goals = PlayerPrefs.GetInt("Goals");
        }

        public static void End()
        {
            for (var i = 0; i < upgrades.Count; i++)
                PlayerPrefs.SetInt("upgrade_" + i, upgrades[i]);

            PlayerPrefs.SetInt("Goals", Goals);
        }

        public static void ClearSave()
        {
            upgrades.Clear();
            PlayerManager._instance.goals = Goals = 0;

            for (var i = 0; i < 10; i++)
                PlayerPrefs.SetInt("upgrade_" + i, 0);

            PlayerPrefs.SetInt("Goals", Goals);
        }
    }
}
