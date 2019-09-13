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
            if (_instance == null) return;
            if (_instance.left.IsDestroyed()) return;

            if (!SaveInfo.openedIndexes.Contains(index - 1))
                _instance.left.interactable = false;
            else
                _instance.left.interactable = true;
            

            if(!SaveInfo.openedIndexes.Contains(index+1))
                _instance.right.interactable = false;
            else
                _instance.right.interactable = true;
        }
    }
}
