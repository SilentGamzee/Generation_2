using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Korzina.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        public Text goals_text;
        public int Tiers_count;
        public int Girls_count;
        public int Poses_count;

        public int max_tier = 0;
        public int max_girl = 0;
        public int max_pos = 0;

        public int current_tier = 0;

        public int goals { get => goals1;
            set
            {
                goals1 = value;
                OnGoalsChanged();
            }
        }

        public static PlayerManager _instance;
        private int goals1;

        void Awake()
        {
            _instance = this;
            goals_text.text = "Goals: 0";
        }

        void OnGoalsChanged()
        {
            goals_text.text = "Goals: " + goals;
        }


    }
}
