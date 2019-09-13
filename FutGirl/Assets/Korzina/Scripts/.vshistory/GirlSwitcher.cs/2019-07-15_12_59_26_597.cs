﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Korzina.Scripts
{
    public class GirlSwitcher : MonoBehaviour
    {
        public Button left;
        public Button right;

        public static GirlSwitcher _instance;
        void Start()
        {
            _instance = this;
            left.onClick.AddListener(OnLeft);
            right.onClick.AddListener(OnRight);
            left.interactable = false;
            right.interactable = false;
        }

        void OnLeft()
        {

        }

        void OnRight()
        {

        }

        public static void OnIndexChange(int index)
        {
            _instance.left.interactable = index > 0;
            var tier_obj = new TierObject(index);
        }
    }
}
