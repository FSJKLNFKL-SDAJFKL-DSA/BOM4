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
    public AudioSource audioSource;

    void Start()
    {
        enemyHealth = 40;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        targetGO = GameObject.Find("Player");
        audioSource = GameObject.Find("enemyAudio").GetComponent<AudioSource>(); 
    }

    void Update()
    {
        target = targetGO.GetComponent<Transform>();
        agent.SetDestination(target.position);
        if (enemyHealth == 0)
        {
            Destroy(gameObject);
            ScoreManager.score++;
        }
        if (agent.velocity.x >= -0.2)
        {
            gameObject.transform.localScale = new Vector3(1, 0.9343013f);
        }
        if (agent.velocity.x <= 0.2)
        {
            gameObject.transform.localScale = new Vector3(-1, 0.9343013f);
        }


    }


    public void takeDamageEmeny(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth == 0)
        {
            if (audioSource != null)
            {
                audioSource.volume = 1;
                audioSource.Play();
            }

            ScoreManager.score++;
            Destroy(gameObject);
        }
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
