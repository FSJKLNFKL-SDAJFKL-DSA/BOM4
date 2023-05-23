using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    float movespeed;
    float movementX;
    float movementY;

    void Start()
    {
        movespeed = 15f;
    }

    private void FixedUpdate()
    {
        Move();
    }


    //movement
    void Move() 
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(movementX, 0f, 0f) * movespeed * Time.deltaTime;
        transform.position += new Vector3(0f, movementY, 0f) * movespeed * Time.deltaTime;

    }
}
