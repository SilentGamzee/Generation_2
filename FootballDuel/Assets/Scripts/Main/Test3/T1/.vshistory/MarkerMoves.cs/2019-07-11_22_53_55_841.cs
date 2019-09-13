using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Main.Test3.T1
{
    public class MarkerMoves:MonoBehaviour
    {
        private Vector3 start_pos;
        public bool isMoveLeft = false;
        void Start()
        {
            start_pos = transform.position;
        }

    }
}
