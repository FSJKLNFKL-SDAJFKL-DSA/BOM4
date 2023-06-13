using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAIMovement : MonoBehaviour
{
    public float enemyHealth;
    public int damageAmount = 20;
    private float damageDelay = 1f;

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

    public void takeDamageEmeny(int damage)
    {
        enemyHealth -= damage;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("gets here");
            PlayerBehavior pb = collision.GetComponent<PlayerBehavior>();
            //dealDamage(damageAmount, collision);  
            StartCoroutine(dealDamage(pb));
        }
    }
    private IEnumerator dealDamage(PlayerBehavior pb)
    {
        yield return new WaitForSeconds(2.0f);
        pb.takeDamage(90);
    }
}
