using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main.Test6
{
    public class ShopUpgradeObject:MonoBehaviour
    {
        public int cost;
        public int cost_mult;
        public int require_lvl;

        void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(OnUpgrade);
        }
        void OnUpgrade()
        {

        }
    }
}
