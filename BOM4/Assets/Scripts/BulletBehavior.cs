using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rb;
    public Collider2D player;
    private Collider2D bulletCollider2d;
    void Start()
    {
        bulletCollider2d = GetComponent<Collider2D>();

        rb.velocity = transform.up * speed;
        Physics2D.IgnoreCollision(player, bulletCollider2d);
    }
}
