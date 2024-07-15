using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoonAttackBehaviorScript : WeaponBehaviorBase
{
    MoonAttackScript moonAttck_script;
    public WeaponScriptableObject WeaponData;

    private float radius = 1f;
    private float angle = 0f;
    private float rotSpeed = .6f;

    [SerializeField] private GameObject popUpPrefab;

    protected override void Start()
    {
        base.Start();
        moonAttck_script = FindAnyObjectByType<MoonAttackScript>();
    }

    private void Update()
    {
        // Going in circles around the player
        float x = playerMovement_script.transform.position.x + Mathf.Cos(angle) * radius;
        float y = playerMovement_script.transform.position.y + Mathf.Sin(angle) * radius;
        float z = playerMovement_script.transform.position.z;

        transform.position = new Vector3(x, y, z);

        angle += WeaponData.speed * Time.deltaTime;

        // Rotating
        transform.Rotate(0, 0, rotSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Get the enemy controller component of the collided object
            EnemyMovementScript enemy_movement_script = collision.GetComponent<EnemyMovementScript>();
            enemy_movement_script.Damage(WeaponData.damage);

            // Setting dir to dmgpopUp && Popping up
            GameObject popUp = Instantiate(popUpPrefab, new Vector2(enemy_movement_script.transform.position.x, enemy_movement_script.transform.position.y - 1), Quaternion.identity);
            popUp.GetComponentInChildren<TMP_Text>().text = WeaponData.damage.ToString();
            if (transform.position.x > collision.transform.position.x)
            {
                popUp.GetComponent<PopUpDmgScript>().hitFromRight = true;
            }

        }

    }
}
