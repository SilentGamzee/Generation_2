using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Main.Test6
{
    public class BottomCollider
    {
        void OnColliderEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "bottom")
                GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
        }
    }
}
