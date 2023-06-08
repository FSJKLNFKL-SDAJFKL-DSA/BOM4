using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{

    public GameObject Enemie;
    public float spawningTime;
    void Start()
    { 
    
    }


    void Update()
    {
        spawningTime = Time.time;
        if (spawningTime > 10) 
        {
            var enemieLVL1 = Instantiate(Enemie);
            spawningTime = 0;
        }
    }
}
