using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    public int Spawncount;
    public GameObject Enemie;
    public float spawningTime;
    private int i;
    void Start()
    {
        i = 0;
    }


    void Update()
    {
        spawnEnemy();
        spawningTime = 1 * Time.time;
    }

    void spawnEnemy()
    {
        if (spawningTime >= 1f && i <= Spawncount)
        {
            var enemyClone = Instantiate(Enemie, transform);
            i++;
        }
    }
}
