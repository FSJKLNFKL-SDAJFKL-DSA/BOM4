using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemieBehavior : MonoBehaviour
{
    public float enemyHealth;
    public int damageAmount = 20;
    private GameObject targetGO;
    private Transform target;
    NavMeshAgent agent;
    public bool canHitPlayer = true;
    private GameObject smobj;

    void Start()
    {
        enemyHealth = 40;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        targetGO = GameObject.Find("Player");
        smobj = GameObject.Find("Canvas");
    }

    void Update()
    {
        target = targetGO.GetComponent<Transform>();
        agent.SetDestination(target.position);
        if (enemyHealth == 0)
        {
            Destroy(gameObject);
            ScoreManager sm = smobj.GetComponent<ScoreManager>();
            sm.score++;
        }
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
        pb.takeDamage(20);
        yield return new WaitForSeconds(3.0f);
        canHitPlayer = true;
    }
}
