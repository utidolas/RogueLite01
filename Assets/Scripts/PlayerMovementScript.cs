using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour, IDamageable
{

    // Components within the object
    private Rigidbody2D rb;
    private Animator anim;

    // Components outside the object
    private MageShootScript furBall_script;

    // Serialized Vars
    [SerializeField] private float playerSpeed;
    [SerializeField] HealthBarScript healthBar_script;

    [SerializeField] float maxHealth = 1000;
    [SerializeField] float currentHealth = 1000;

    // Vars
    float dirX;
    float dirY;

    private void Start()
    {
        furBall_script = FindFirstObjectByType<MageShootScript>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthBar_script.UpdateHealthBar(currentHealth, maxHealth);
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        // Changing char rotation and animation according to x's and y-axis
        Rotating(dirX, dirY);
        if (dirX != 0)
        {
            anim.SetFloat("isWalking", Mathf.Abs(dirX));

        }
        else
        {
            anim.SetFloat("isWalking", Mathf.Abs(dirY));
        }

        // Changing to attack anim
        if (!furBall_script.canFire)
        {
            anim.SetBool("hasAttacked", true);
        }
        else
        {
            anim.SetBool("hasAttacked", false);
        }

    }

    // Moving player
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY).normalized * playerSpeed * Time.deltaTime; 
    }

    private void Rotating(float dirX, float dirY)
    {
        if (dirX > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (dirX < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }

    //==================== DAMAGE AND DIE ====================
    public void Damage(float dmg)
    {
        currentHealth -= dmg;
        healthBar_script.UpdateHealthBar(currentHealth, maxHealth);
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }
}
