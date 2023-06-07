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
    public Transform Gun;
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
        rotateSprite();
    }

    void Shoot()
    {
        var cloneBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        cloneBullet.transform.Rotate(0, 0, 90);
        Destroy(cloneBullet, 1f);
    }

    void Rotate()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        UnityEngine.Vector2 aimdirection =  mousePosition - rb.position;
        pivotPoint.transform.up = aimdirection;
    }

    private void rotateSprite()
    {
        if (pivotPoint.transform.rotation.eulerAngles.z % 360 >= 0f && pivotPoint.transform.rotation.eulerAngles.z % 360 <= 180f)
        {
            Gun.transform.localScale = new UnityEngine.Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            Gun.transform.localScale = new UnityEngine.Vector3(0.5f, -0.5f, 0.5f);
        }
    }
}
