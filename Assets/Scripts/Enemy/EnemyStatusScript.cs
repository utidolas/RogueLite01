using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusScript : MonoBehaviour
{
    public EnemyScriptableObject EnemyData;

    public float CurrentMoveSpeed;
    public float CurrentHealth;
    public float CurrentDamage;
    public float CurrentExpAmount;

    private void Awake()
    {
        CurrentMoveSpeed = EnemyData.EnemySpeed;
        CurrentHealth = EnemyData.MaxHealth;
        CurrentDamage = EnemyData.Damage;
        CurrentExpAmount = EnemyData.ExpAmount;
    }
}
