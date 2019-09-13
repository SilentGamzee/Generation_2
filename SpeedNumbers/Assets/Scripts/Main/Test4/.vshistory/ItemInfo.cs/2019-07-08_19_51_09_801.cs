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
            var sprite = LevelManager._instance.item_sprites_list[num];
            this.gameObject.GetComponent<Image>().sprite = sprite;
        }

        public void DealDamage(int damage_count)
        {
            hp -= damage_count;

            if (hp <= 0)
            {
                this.gameObject.SetActive(false);
                LevelManager.OnLevelItemChanged(this.gameObject);
                return;
            }

            if (num - 1 < LevelManager._instance.item_sprites_list.Count)
            {
                num--;
                UpdateImage();
            }


        }
    }
}
