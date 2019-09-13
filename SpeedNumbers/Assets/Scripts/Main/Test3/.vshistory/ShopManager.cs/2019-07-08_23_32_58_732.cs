using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main.Test3
{
    public class ShopManager:MonoBehaviour
    {
        public Button ball_dmg_button;
        public Button lives_button;
        public Button jump_button;

        void Start()
        {
            ball_dmg_button.onClick.AddListener(OnDmgUp);
            lives_button.onClick.AddListener(OnLivesUp);
        }

        void OnDmgUp()
        {

        }

        void OnLivesUp()
        {

        }
    }
}
