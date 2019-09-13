using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Korzina.Scripts
{
   
    public class SaveInfo
    {
        public static List<int> upgrades = new List<int>();

        public static void Start()
        {

        }

        public static void End()
        {

            PlayerPrefs.SetInt("highestScore", playerProgress.highestScore);
        }
    }
}
