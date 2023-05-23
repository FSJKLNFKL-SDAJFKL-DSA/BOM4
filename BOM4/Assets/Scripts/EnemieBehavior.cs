using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieBehavior : MonoBehaviour
{
    int damage;
    public PlayerBehavior PlayerBehavior;
    public float wait;

    void Start()
    {
        damage = 20;
    }

    void Update()
    {
        
    }

    //inital damage on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerBehavior.takeDamage(damage);
        }
    }

    //tick damage when player stays in collider
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wait += Time.deltaTime;

            if (wait >= 0.5f)
            {
                PlayerBehavior.takeDamage(damage);
                wait = 0f;
            }
        }
    }
}
