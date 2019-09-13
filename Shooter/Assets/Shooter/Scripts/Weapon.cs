using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "Weapons")]
public class Weapon : ScriptableObject
{
    public Sprite Icon;
    public float Damage;
}
