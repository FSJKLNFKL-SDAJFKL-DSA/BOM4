using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAIMovement : MonoBehaviour
{
    public float enemyHealth;
    public int damageAmount = 20;

    [SerializeField] Transform target;
    NavMeshAgent agent;

    void Start()
    {
        enemyHealth = 20;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerBehavior>().takeDamage(damageAmount);
        }
    }
}
