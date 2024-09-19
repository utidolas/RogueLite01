using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]

public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField]
    float damage;
    public float Damage { get =>  damage; private set => damage = value; }

    [SerializeField]
    float enemySpeed;
    public float EnemySpeed { get => enemySpeed; private set => enemySpeed = value; }

    [SerializeField]
    float expAmount;
    public float ExpAmount { get => expAmount; private set => expAmount = value; }
}
