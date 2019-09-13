using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.Test3.T1
{
    public class MarkerMoves:MonoBehaviour
    {
        private Vector3 start_pos;
        void Start()
        {
            start_pos = transform.position;
        }

        float t = 0;
        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
            t += Time.deltaTime;
            if (t < 1f) return;
            t = 0;

            var need_x = start_pos.x - 2f;
        }
    }
}
