using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour, IDamageable
{

    // Components within the object
    private Rigidbody2D rb;
    private Animator anim;
    private InventoryManager inventory;
    public PlayerStatus player_status;

    // Components outside the object
    private MageShootScript mageShoot_script;
    public PlayerScriptableObject PlayerData;

    // Serialized Vars
    [SerializeField] HealthBarScript healthBar_script;

    // Vars
    float dirX;
    float dirY;
    int weaponIndex;

    // Spawned weapons
    public List<GameObject> spawnedWeapons;

    private void Awake()
    {
        inventory = GetComponent<InventoryManager>();
        mageShoot_script = FindFirstObjectByType<MageShootScript>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Spawn the start weapon
        SpawnWeapon(PlayerData.StartingWeapon);
    }

    private void Start()
    {
        healthBar_script.UpdateHealthBar(player_status.CurrentHealth, PlayerData.MaxHealth);
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
        if (!mageShoot_script.canFire)
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
        rb.velocity = new Vector2(dirX, dirY).normalized * player_status.CurrentSpeed * Time.deltaTime; 
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
        player_status.CurrentHealth -= dmg;
        healthBar_script.UpdateHealthBar(player_status.CurrentHealth, PlayerData.MaxHealth);
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    //==================== WEAPONS ====================

    //Spawn weapon
    public void SpawnWeapon(GameObject weapon)
    {
        // Check if list not full
        if(weaponIndex >= inventory.weaponSlots.Count - 1)
        {
            Debug.LogError("Full inventory");
            return;
        }

        // Spawn weapon, set as child, add to inventory
        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        inventory.AddWeapon(weaponIndex, spawnedWeapon.GetComponent<WeaponBase>());

        weaponIndex++;
    }
}
