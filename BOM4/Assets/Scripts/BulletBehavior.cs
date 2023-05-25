using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.up * speed;
    }
}
