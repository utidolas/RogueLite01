using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MageShootBulletScript : MonoBehaviour
{
    // Components inside object
    private Rigidbody2D rb;

    // Components outside object
    private Camera mainCam;
    private Vector3 mousePos;

    // Serialized Vars
    [SerializeField] private float force;
    [SerializeField] private float damage = 1f;
    [SerializeField] private GameObject popUpPrefab;

    // Vars
    private bool hasHitEnemy = false;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        Vector3 rotationDir = transform.position - mousePos;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * force;
        float rotation = Mathf.Atan2(rotationDir.y, rotationDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 180);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if can hit and enemy
        if (!hasHitEnemy && collision.CompareTag("Enemy"))
        {
            // Get the enemy controller component of the collided object
            EnemyMovementScript enemy_movement_script = collision.GetComponent<EnemyMovementScript>();

            // Setting dir to dmgpopUp && Popping up
            GameObject popUp = Instantiate(popUpPrefab, new Vector2(enemy_movement_script.transform.position.x, enemy_movement_script.transform.position.y - 1), Quaternion.identity);
            popUp.GetComponentInChildren<TMP_Text>().text = damage.ToString();
            if(transform.position.x > collision.transform.position.x)
            {
                popUp.GetComponent<PopUpDmgScript>().hitFromRight = true;
            }

            enemy_movement_script.Damage(damage);
            hasHitEnemy = true;
            Destroy(gameObject);
        }

    }
}
