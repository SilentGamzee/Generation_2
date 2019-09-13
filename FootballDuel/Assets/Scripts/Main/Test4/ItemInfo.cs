using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class ItemInfo:MonoBehaviour
    {
        public int num = 0;
        public int hp = 1;

        public void UpdateImage()
        {
            if (num < 0) return;
            var sprite = LevelManager._instance.item_sprites_list[num];
            this.gameObject.GetComponent<Image>().sprite = sprite;
        }

       
    }
}
