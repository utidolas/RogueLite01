using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MageShootScript : MonoBehaviour
{
    // Components outside the object

    // Serialized vars
    [SerializeField] GameObject player_object;
    [SerializeField] GameObject bullet;
    [SerializeField] private float timeBetweenFire = .6f;

    // Vars
    public bool canFire { get; private set; }
    private float timer;

    private void Start()
    {
        canFire = true;
    }

    private void Update()
    {
        // FireRate
        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFire)
            {
                canFire = true;
                timer = 0;
            }
        }

        InstantiateBullet();

    }

    // Instantiate object when left mouse clicks
    public void InstantiateBullet()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet ,player_object.transform.position, Quaternion.identity);
        }
    }



}
