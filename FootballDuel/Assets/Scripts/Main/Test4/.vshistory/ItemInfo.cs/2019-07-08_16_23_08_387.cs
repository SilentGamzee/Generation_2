using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main
{
    class ItemInfo:MonoBehaviour
    {
        public int num = 0;
        public int hp = 1;

        public void DealDamage(int damage_count)
        {
            hp -= damage_count;

        }
    }
}
