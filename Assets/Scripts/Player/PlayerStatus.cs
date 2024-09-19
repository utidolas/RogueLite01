using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public PlayerScriptableObject PlayerData;

    public float CurrentHealth;
    public float CurrentSpeed;
    private void Awake()
    {
        CurrentHealth = PlayerData.MaxHealth;
        CurrentSpeed = PlayerData.Speed;
    }
}
