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
        public Text error_shop_text;

        public static ShopManager _instance;

        void Start()
        {
            _instance = this;

        }

        void Update()
        {
                
        }
    }
}
