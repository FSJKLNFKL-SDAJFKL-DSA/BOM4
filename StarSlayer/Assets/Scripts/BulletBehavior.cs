using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 30;
    public Rigidbody2D rb;
    public Collider2D player;
    private GameObject playerGO;
    private Collider2D bulletCollider2d;
    void Start()
    {
        bulletCollider2d = GetComponent<Collider2D>();
        playerGO = GameObject.Find("Player");
        player = playerGO.GetComponent<Collider2D>();
        rb.velocity = transform.right * speed;
        Physics2D.IgnoreCollision(player, bulletCollider2d);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemieBehavior eb = collision.GetComponent<EnemieBehavior>();
            eb.takeDamageEmeny(20);
            Destroy(gameObject);
        }
    }
}
