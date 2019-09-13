using Assets.Scripts.Main.Test5.T1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main.Test3
{
    public class ShopManager : MonoBehaviour
    {
        public Button ball_dmg_button;
        public Button lives_button;
        public Button jump_button;

        public static ShopManager _instance;

        public static int ball_dmg_cost = 10;
        public static int lives_cost = 10;
        public static int jump_cost = 10;
        void Start()
        {
            _instance = this;
          
        }

       void Update()
        {

        }
    }
}
