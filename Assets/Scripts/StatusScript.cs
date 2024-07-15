using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusScript : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
}
