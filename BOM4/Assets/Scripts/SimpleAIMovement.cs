using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAIMovement : MonoBehaviour
{
    public float enemyHealth;
    public int damageAmount = 20;

    private GameObject targetGO;
    private Transform target;
    NavMeshAgent agent;

    void Start()
    {
        enemyHealth = 20;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        targetGO = GameObject.Find("Player");
    }

    void Update()
    {
        target = targetGO.GetComponent<Transform>();
        agent.SetDestination(target.position);
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerBehavior>().takeDamage(damageAmount);
        }
    }
}
