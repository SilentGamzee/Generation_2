using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bottom")
        {
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
            Destroy(this.gameObject);
        }
        
    }
    void Update()
    {
        transform.Translate(0, -Time.deltaTime, 0);
    }
}
