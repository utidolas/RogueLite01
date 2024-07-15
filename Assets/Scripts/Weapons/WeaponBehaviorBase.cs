using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviorBase : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfter;

    protected PlayerMovementScript playerMovement_script;

    virtual protected void Start()
    {
        playerMovement_script = FindAnyObjectByType<PlayerMovementScript>();
        Destroy(gameObject, destroyAfter);
    }

    public void Dir(Vector3 dir)
    {
        direction = dir;
    }
}
