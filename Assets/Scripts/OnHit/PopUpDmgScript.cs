using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpDmgScript : MonoBehaviour
{
    public Vector2 InitialVelocity;
    private Rigidbody2D rb;

    private float lifeTime = .5f;
    public bool hitFromRight;

    private void Start()
    {
        if (hitFromRight)
        {
            InitialVelocity.x *= -1;
        }

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = InitialVelocity;
        Destroy(gameObject, lifeTime);
    }

}
