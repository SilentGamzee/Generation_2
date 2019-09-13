using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHandlerGirl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelController.Instance.Scored = true;
    }
}
