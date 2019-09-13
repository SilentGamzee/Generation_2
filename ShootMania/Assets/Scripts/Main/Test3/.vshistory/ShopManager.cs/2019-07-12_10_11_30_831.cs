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
        public GameObject error_shop_text;

        public static ShopManager _instance;

        private static float t = 0;
        public static void OnNotEnoughMoney()
        {
            t = 2f;
            _instance.error_shop_text.SetActive(true);
        }

        void Start()
        {
            _instance = this;

        }

        void Update()
        {
            if (t <= 0) return;
            t -= Time.deltaTime;

        }
    }
}
