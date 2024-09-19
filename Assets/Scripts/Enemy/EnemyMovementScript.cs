using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovementScript : MonoBehaviour, IDamageable
{
    // Components inside the object
    public EnemyStatusScript enemyStatus_script;

    // Components outside the object
    private GameObject player_object;
    public EnemyScriptableObject enemyData;

    // Serialized Vars
    [SerializeField] UnityEvent whenDamage;


    private void Start()
    {
        player_object = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player_object.transform.position, enemyStatus_script.CurrentMoveSpeed * Time.deltaTime);
        RotateToPlayer();

    }

    // Rotates y-axis to player
    private void RotateToPlayer()
    {
        if(player_object.transform.position.x < transform.position.x)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }

    // ==================== DAMAGE AND DIE ====================
    public void Damage(float dmg)
    {
        enemyStatus_script.CurrentHealth -= dmg;
        if (enemyStatus_script.CurrentHealth <= 0)
        {
            player_object.GetComponent<LevelScript>().AddExp(enemyStatus_script.CurrentExpAmount);
            Die();
        }
        whenDamage.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    // ==================== ATTACK PLAYER ====================
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementScript>())
        {
            Debug.Log("Collided");
            Attack();
        }
    }

    private void Attack()
    {
        player_object.GetComponent<PlayerMovementScript>().Damage(enemyStatus_script.CurrentDamage);
    }
}
