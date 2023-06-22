using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PShooterBehavior : MonoBehaviour
{
    public GameObject Player;
    private Vector3 playerPos;
    private Vector3 targetScreenPos;
    private Vector3 targetWorldPos;

    void Start()
    {
        
    }

    void Update()
    {
        //move Gun to player
        playerPos = Player.transform.position + new Vector3(0, 0.7f);
        transform.position = playerPos;
        gunRotation();
    }


    //rotate the Gun around the Player Towards the pos of the mouse
    void gunRotation()
    {

        //get pos of the mouse
        targetScreenPos = Input.mousePosition;
        targetWorldPos = Camera.main.ScreenToWorldPoint(targetScreenPos) - new Vector3(0, 0, Camera.main.ScreenToWorldPoint(targetScreenPos).z);

        //rotate Gun in direction of mouse
        Vector3 Dir = targetWorldPos - playerPos;
        transform.up = Dir;
    }
}
