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

        public static void Start()
        {
            for (var i = 0; i < 10; i++)
                PlayerPrefs.SetInt("upgrade_" + i, upgrades[i]);
        }

        public static void End()
        {
            for(var i=0;i< upgrades.Count;i++)
                PlayerPrefs.SetInt("upgrade_"+i, upgrades[i]);
        }
    }
}
