using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main
{
    class WaiterUpdater:MonoBehaviour
    {
        public GameObject waiter;

        void Update()
        {
            var state = GameCoordinator.GetGameState();
            if (state != GameCoordinator.GameStates.Moving)
            {
                waiter.SetActive(false);
                return;
            }
            waiter.SetActive(true);
            waiter.transform.Rotate(0, 0, 1.5f, Space.Self);
        }
    }
}
