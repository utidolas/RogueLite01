using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WeaponScriptableObjects", menuName ="ScriptableObject/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    public GameObject WeaponPrefab;
    // weapon stats
    public float damage;
    public float speed;
    public float cooldown;
    public int piercing;
}
