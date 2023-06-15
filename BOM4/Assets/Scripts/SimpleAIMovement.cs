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
    public bool canHitPlayer = true;

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

    public void takeDamageEmeny(int damage)
    {
        enemyHealth -= damage;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && canHitPlayer == true)
        {
            PlayerBehavior pb = collision.collider.GetComponent<PlayerBehavior>();
            canHitPlayer = false;
            StartCoroutine(dealDamage(pb));
        }
    }
    private IEnumerator dealDamage(PlayerBehavior pb)
    {
        pb.takeDamage(90);
        yield return new WaitForSeconds(2.0f);
        canHitPlayer = true;
    }
}
