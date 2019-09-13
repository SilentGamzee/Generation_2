using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Korzina.Scripts
{
    public class GirlSwitcher:MonoBehaviour
    {
        public Button left;
        public Button right;

        void Start()
        {
            left.onClick.AddListener(OnLeft);
            right.onClick.AddListener(OnRight);
        }

        void OnLeft()
        {

        }

        void OnRight()
        {

        }

        public static void OnIndexChange(int index)
        {

        }
    }
}
