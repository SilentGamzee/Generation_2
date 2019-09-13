using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    

    
    
    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving)
        {
            Destroy(this.gameObject);
            return;
        }
        transform.Translate(0, -Time.deltaTime, 0);
    }
}
