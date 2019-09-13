using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.Test6
{
    public class BulletObject:MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "top")
                Destroy(this.gameObject);
            else if(collision.gameObject.tag == "enemy")
            {
                MoveCoordinator.P++;
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}
