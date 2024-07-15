using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonAttackScript : WeaponBase
{

    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject moonPrefab = Instantiate(WeaponData.WeaponPrefab);
        moonPrefab.transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
    }
}
