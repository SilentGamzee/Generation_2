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
        public int Tiers_count;
        public int Girls_count;
        public int Poses_count;

        public int max_tier=0;
        public int max_girl=0;
        public int max_pos=0;

        public int current_tier;
        public int current_girl;
        public int current_pos;

        public static PlayerManager _instance;
        void Awake()
        {
            _instance = this;
        }


    }
}
