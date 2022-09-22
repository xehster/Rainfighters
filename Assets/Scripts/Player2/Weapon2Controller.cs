using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2Controller : MonoBehaviour
{
    public Transform firePoint;
    public BulletView bulletView;

    private void Start()
    {

    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            var bullet = Instantiate(bulletView, firePoint.position, firePoint.rotation);

            //Vector2 direction = Vector2.right;
            //Ray ray = new Ray(firePoint.transform.position, transform.TransformDirection(direction * 100));
            //Debug.DrawRay(firePoint.transform.position, transform.TransformDirection(direction * 100));

        }
    }
}
