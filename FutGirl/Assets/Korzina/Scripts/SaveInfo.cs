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

            for (var i = 0; i < 10; i++)
                if (PlayerPrefs.HasKey("upgrade_" + i))
                {
                    var v = PlayerPrefs.GetInt("upgrade_" + i);
                    if (!upgrades.Contains(v))
                        upgrades.Add(v);
                }

            var manager = PlayerManager._instance;
            for (var i = 0; i < manager.Tiers_count * manager.Girls_count * manager.Poses_count; i++)
                if (PlayerPrefs.HasKey("index_" + i))
                {
                    var v = PlayerPrefs.GetInt("index_" + i);
                    if (!openedIndexes.Contains(v))
                        openedIndexes.Add(v);
                }

            if (PlayerPrefs.HasKey("Goals"))
                PlayerManager._instance.goals = PlayerPrefs.GetInt("Goals");
        }

        public static void End()
        {
            for (var i = 0; i < upgrades.Count; i++)
                PlayerPrefs.SetInt("upgrade_" + i, upgrades[i]);

            for (var i = 0; i < openedIndexes.Count; i++)
                PlayerPrefs.SetInt("index_" + i, openedIndexes[i]);

            PlayerPrefs.SetInt("Goals", Goals);
        }

        public static void ClearSave()
        {
            
            upgrades.Clear();
            openedIndexes.Clear();
            PlayerManager._instance.goals = Goals = 0;
            PlayerPrefs.DeleteAll();
            
        }
    }
}
