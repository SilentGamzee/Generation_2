using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.Test6
{
    public class PanelManager : MonoBehaviour
    {
        public GameObject shop_panel;
        public GameObject city_panel;
        public GameObject playground_panel;
        public GameObject city_bottom_panel;
        public GameObject game_end_panel;

        private static PanelManager _instance;

        void Awake()
        {
            _instance = this;
        }

        public static PanelManager Get() => _instance;

        public static void OpenGamePanel()
        {
            _instance.city_panel.SetActive(false);
            _instance.playground_panel.SetActive(true);
            _instance.shop_panel.SetActive(false);
        }
    }
}
