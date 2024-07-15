using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject WeaponData;

    float currentCooldown;

    protected PlayerMovementScript playerMovement_script;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        currentCooldown = WeaponData.cooldown;
        playerMovement_script = FindAnyObjectByType<PlayerMovementScript>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0)
        {
            Attack();
        }
    }

    virtual protected void Attack()
    {
        currentCooldown = WeaponData.cooldown;
    }
}
