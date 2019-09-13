using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main
{
    class GameCoordinator : MonoBehaviour
    {
        //PUBLIC EDITOR
        [SerializeField] private GameStates gameState = GameStates.WaitingToStart;

        //PUBLIC ENUM
        public enum GameStates
        {
            Nothing,
            Moving,
            WaitingToStart,
            GameEnd,
            Lose,
            Pause
        }

        //PUBLIC STATIC
        public static GameCoordinator _instance;

        void Start()
        {
            _instance = this;
        }

        public static void UpdateState(GameStates state)
        {
            _instance.gameState = state;
        }

        public static GameStates GetGameState()
        {
            return _instance.gameState;
        }
    }
}
