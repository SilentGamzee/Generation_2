using System;
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
            LevelController._instance.PreviousImage();
        }

        void OnRight()
        {
            LevelController._instance.NextImage();
        }

        public static void OnIndexChange(int index)
        {
            var player_manager = PlayerManager._instance;
            _instance.left.interactable = index > 0;
            var tier_obj = new TierObject(index);

            //if next index tier bigger than our max achieved or
            //that tier equal max achieved and bigger than max achieved girl or pos
            if(tier_obj.tier>player_manager.max_tier 
                || (tier_obj.tier==player_manager.current_tier
                && (tier_obj.girl >= player_manager.max_girl || tier_obj.pos >= player_manager.max_pos)))
                _instance.right.interactable = false;
            else
                _instance.right.interactable = true;
        }
    }
}
