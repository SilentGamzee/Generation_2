using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main
{
    class ResolutionChecker : MonoBehaviour
    {
        //PUBLIC EDITOR
        public Camera MainCamera;

        //PRIVATE
        Vector3 initBottomLeft;
        Vector3 initTopRight;

        void Start()
        {
            initBottomLeft = MainCamera.ScreenToWorldPoint(new Vector3(0, 0, 30));
            initTopRight = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 30)); // I used 30 as my camera z is -30
        }


        private static void OnResolutionChange()
        {

        }

        void Update()
        {
            var updBtmLeft = MainCamera.ScreenToWorldPoint(new Vector3(0, 0, 30));
            var updTopRght = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 30));

            if ((initBottomLeft != updBtmLeft) || (initTopRight != updTopRght))
            {
                initBottomLeft = updBtmLeft;
                initTopRight = updTopRght;
                OnResolutionChange();
            }
        }
    }
}
