using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovementScript : MonoBehaviour, IDamageable
{
    // Components within the object
    public StatusScript status_script;
    public FlashDamage flashDamage_script;

    // Components outside the object
    private GameObject player_object;

    // Serialized Vars
    [SerializeField] private float enemySpeed = .03f;
    [SerializeField] UnityEvent whenDamage;
    [SerializeField] private float expAmount;

    // Vars
    int damage = 100;

    private void Start()
    {
        status_script = GetComponent<StatusScript>();
        player_object = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player_object.transform.position, enemySpeed * Time.deltaTime);
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
        status_script.CurrentHealth -= dmg;
        if (status_script.CurrentHealth <= 0)
        {
            player_object.GetComponent<LevelScript>().AddExp(expAmount);
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
        player_object.GetComponent<PlayerMovementScript>().Damage(damage);
    }
}
