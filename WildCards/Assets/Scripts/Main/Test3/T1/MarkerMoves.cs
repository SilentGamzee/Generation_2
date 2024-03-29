﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.Test3.T1
{
    public class MarkerMoves : MonoBehaviour
    {
        private Vector3 start_pos;
        void Start()
        {
            start_pos = transform.position;
        }

        float t = 0;
        void Update()
        {
            // if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
            t += Time.deltaTime;
            var time = 3f;
            if (PlayerManager.HardMode == PlayerManager.hardmodes.Normal)
                time -= 1f;
            else if (PlayerManager.HardMode == PlayerManager.hardmodes.Hard)
                time -= 2f;

            if (t < time) return;
            t = 0;

            var need_x = start_pos.x - UnityEngine.Random.Range(-2, 2);
            var pos = this.transform.position;
            this.transform.position = new Vector3(need_x, pos.y, pos.z);
        }
    }
}
