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
        public Transform enmemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
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

            }
        }
    }
}
