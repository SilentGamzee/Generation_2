﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class MoveCoordinator : MonoBehaviour
    {
        //PUBLIC EDITOR
        public float MoveSpeed;

        //PRIVATE STATIC
        private static List<float> x_points = new List<float>();
        private static float start_x;
        private static int x = 0;
        private static float delay = 0;
        private static int row_count = 0;

        public static void Init()
        {
            var rows = InitScript._instance.randomRow;
            foreach (var row in rows)
            {
                var x_pos = row.transform.position.x;
                x_points.Add(x_pos);
            }
            start_x = InitScript._instance.randomRow.transform.position.x;

            row_count = rows.Count;
        }

        private static void AddForeground(int num_r)
        {
            var rows = InitScript._instance.gameRows;
            var random_row = InitScript._instance.randomRow;
            var sprites = InitScript._instance.spriteList;

            var trans = rows[num_r].transform;
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);
                var r_item = random_row.transform.GetChild(i);
                if (item.childCount == 0)
                {
                    var child = Instantiate(r_item, new Vector3(item.position.x, item.position.y, item.position.z + 1f), item.rotation);
                    child.transform.SetParent(item);
                    child.GetComponent<RectTransform>().localScale = Vector3.one;
                    
                    child.gameObject.AddComponent<ItemInfo>().num = sprites.IndexOf(child.GetComponent<Image>().sprite);
                }
                else
                {
                    var child = item.GetChild(0);
                    var sprite = r_item.GetComponent<Image>().sprite;
                    child.GetComponent<Image>().sprite = sprite;
                    child.gameObject.SetActive(true);

                    child.gameObject.GetComponent<ItemInfo>().num = sprites.IndexOf(sprite);
                }
            }
        }

        private static void ResetRandomRow()
        {
            var random_trans = InitScript._instance.randomRow.transform;
            random_trans.position = new Vector3(start_x, random_trans.position.y, random_trans.position.z);
        }

        public static void Reset()
        {
            var rows = InitScript._instance.gameRows;
            var random_row = InitScript._instance.randomRow;

            foreach (var row in rows)
            {
                var trans = row.transform;
                for (var i = 0; i < trans.childCount; i++)
                {
                    var item = trans.GetChild(i);
                    var r_item = random_row.transform.GetChild(i);
                    if (item.childCount != 0)
                    {
                        var child = item.GetChild(0);
                        child.gameObject.SetActive(false);
                    }
                }
            }
            x = 0;
        }

        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
            if (x == row_count) return;

            float step = MoveSpeed * Time.deltaTime;
            var r_pos = InitScript._instance.randomRow.transform.position;
            InitScript._instance.randomRow.transform.position = Vector3.MoveTowards(r_pos, new Vector3(x_points[x], r_pos.y, r_pos.z), step);

            if (InitScript._instance.randomRow.transform.position.x == x_points[x])
            {
                AddForeground(x);
                ResetRandomRow();
                InitScript.UpdateImages();

                x++;
                if (x == row_count)
                    GameCoordinator.UpdateState(GameCoordinator.GameStates.PreEnd);
                else
                    GameCoordinator.UpdateState(GameCoordinator.GameStates.Randoming);
            }
        }
    }
}
