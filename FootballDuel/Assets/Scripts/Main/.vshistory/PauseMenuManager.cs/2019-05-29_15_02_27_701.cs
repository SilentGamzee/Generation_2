using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class PauseMenuManager:MonoBehaviour
    {
        //PUBLIC EDITOR
        public GameObject pauseMenu;
        public Button closeButton;
        public Button retryButton;
        public Button exitButton;

        //PRIVATE STATIC
        private static PauseMenuManager _instance;

        void Start()
        {
            _instance = this;
        }

        public static void OpenPause(bool isLose)
        {
            
            _instance.closeButton.gameObject.SetActive(!isLose);

           

        }

    }
}
