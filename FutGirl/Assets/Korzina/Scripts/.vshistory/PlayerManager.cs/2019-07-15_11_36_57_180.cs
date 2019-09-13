using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Korzina.Scripts
{
    public class PlayerManager:MonoBehaviour
    {


        public static PlayerManager _instance;
        void Awake()
        {
            _instance = this;
        }


    }
}
