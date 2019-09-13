using UnityEngine;

/// <summary>
/// Rotate object by axes
/// </summary>
public class Rotator : MonoBehaviour
{
    public float xspeed;
    public float yspeed;
    public float zspeed;
    public bool unscaledTime;

    // Update is called once per frame
    private void Update()
    {
        float timeAnimation = unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
        transform.Rotate(xspeed * timeAnimation, yspeed * timeAnimation, zspeed * timeAnimation);
    }
}