using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { spawning, waiting, counting };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 15f;
    public float waveCountDown;

    public SpawnState state = SpawnState.counting;

    private void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    private void Update()
    {
        if (waveCountDown <= 0)
        {
            if (state != SpawnState.spawning)
            {
                StartCoroutine(spawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    IEnumerator spawnWave(Wave wave)
    {
        Debug.Log(wave.name);
        state = SpawnState.spawning;

        foreach (Wave w in waves)
        {
            spawnEnemy(w.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        state = SpawnState.waiting;
        nextWave++;
        waveCountDown = timeBetweenWaves;

        yield break;
    }

    void spawnEnemy(Transform enemy)
    {
        Debug.Log(enemy.name);
        Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, -1f), transform.rotation);

    }
}
