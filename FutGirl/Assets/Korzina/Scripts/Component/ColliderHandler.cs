using UnityEngine;

public class ColliderHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelController.Instance.Restart();
    }
}