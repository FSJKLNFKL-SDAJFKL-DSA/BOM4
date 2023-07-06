using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public float movespeed;
    float movementX;
    float movementY;
    public float playerHealth;

    // animator nesacities
    public Animator animator;

    void Start()
    {
        playerHealth = 100;
        movespeed = 7f;
    }
    private void FixedUpdate()
    {
        Move();
        if (movementY >= 0.1f || movementY <= -0.1f)
        {
            animator.SetFloat("Vertical", movementY);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetFloat("Vertical", 0);
            animator.SetBool("isMoving", false);
        }
        if (movementX >= 0.1f || movementX <= -0.1f)
        {
            animator.SetFloat("Horizontal", movementX);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetFloat("Horizontal", 0);
        }

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(2);  
        }

    }

<<<<<<< Updated upstream:StarSlayer/Assets/Scripts/PlayerBehavior.cs
=======
<<<<<<< Updated upstream
    //movement
=======
    private void FixedUpdate()
    {
        Move();
    }

>>>>>>> Stashed changes
>>>>>>> Stashed changes:BOM4/Assets/Scripts/PlayerBehavior.cs
    void Move()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(movementX, 0f) * movespeed * Time.deltaTime;
        transform.position += new Vector3(0f, movementY) * movespeed * Time.deltaTime;

    }

    public void takeDamage(int damage)
    {
        playerHealth -= damage;
    }
}