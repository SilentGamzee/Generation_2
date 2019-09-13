using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main.Test6
{
    public class HardModeButton:MonoBehaviour
    {
        public float spawn_bonus_time;
        
        void Start()
        {
            this.GetComponent<Button>().onClick.AddListener(OnClick);
        }

        void OnClick()
        {

        }
    }
}
