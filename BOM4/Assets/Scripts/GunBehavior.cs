using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Networking.Types;
using Quaternion = System.Numerics.Quaternion;

public class GunBehavior : MonoBehaviour
{

    public Transform firePoint;
    public Transform pivotPoint;
    public Camera sceneCamera;
    private UnityEngine.Vector2 mousePosition;
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        Rotate();   
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Rotate()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        UnityEngine.Vector2 aimdirection =  mousePosition - rb.position;
        pivotPoint.transform.up = aimdirection;
    }
}
