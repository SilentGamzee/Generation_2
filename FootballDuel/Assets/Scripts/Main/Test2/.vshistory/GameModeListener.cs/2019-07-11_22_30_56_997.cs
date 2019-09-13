using System;
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

        private static GameModeListener _instance;
        void Start()
        {
            _instance = this;
        }

        static void OnStandart()
        {
            _instance.vratar.SetActive(true);
            _instance.mark.SetActive(false);
        }

        static void OnPoints()
        {
            _instance.vratar.SetActive(false);
            _instance.mark.SetActive(false);
        }
    }
}
