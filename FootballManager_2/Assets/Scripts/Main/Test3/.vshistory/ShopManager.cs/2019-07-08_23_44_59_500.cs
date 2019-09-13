using Assets.Scripts.Main.Test5.T1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main.Test3
{
    public class ShopManager : MonoBehaviour
    {
        public Button ball_dmg_button;
        public Button lives_button;
        public Button jump_button;

        public static ShopManager _instance;

        public static int ball_dmg_cost = 10;
        public static int lives_cost = 10;
        public static int jump_cost = 10;
        void Start()
        {
            _instance = this;
            ball_dmg_button.onClick.AddListener(OnDmgUp);
            lives_button.onClick.AddListener(OnLivesUp);
            jump_button.onClick.AddListener(OnJumpUp);
        }

        void OnDmgUp()
        {
            if (MoveCoordinator.P < ball_dmg_cost) return;
            MoveCoordinator.P -= ball_dmg_cost;
            ball_dmg_cost += (int)(ball_dmg_cost / 3f);
            ball_dmg_button.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "" + ball_dmg_cost;
            BallCollider.ball_damage++;
        }

        void OnLivesUp()
        {
            if (MoveCoordinator.P < lives_cost) return;
            MoveCoordinator.P -= lives_cost;
            lives_cost += (int)(lives_cost / 3f);
            lives_button.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "" + lives_cost;
            ButtonListener.Lives_max++;
        }

        void OnJumpUp()
        {
            if (MoveCoordinator.P < lives_cost) return;
            MoveCoordinator.P -= lives_cost;
            lives_cost += (int)(lives_cost / 3f);
            lives_button.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "" + lives_cost;
            ButtonListener.extra_jump_max++;
        }
    }
}
