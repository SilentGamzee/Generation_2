﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.Test2
{
    public class GameModeListener:MonoBehaviour
    {
        public GameObject vratar;
        public GameObject mark;
        void OnStandart()
        {
            vratar.SetActive(true);
            mark.SetActive(false);
        }

        void OnPoints()
        {

        }
    }
}
