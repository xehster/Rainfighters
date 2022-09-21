using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float bulletSpeed = 100;
    public Transform firePoint;
    public BulletView bulletView;
    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var bullet = Instantiate(bulletView, firePoint.position, firePoint.rotation);
            bullet.SetBulletData(bulletSpeed);
        }
    }
}
