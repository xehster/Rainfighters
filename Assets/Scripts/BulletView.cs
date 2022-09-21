using System;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public float projectileSpeed = 20f;
    private Vector3 bulletPrevPos;

    private void Start()
    {
        bulletPrevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RayShooting();
    }

    void RayShooting()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);

        bulletPrevPos = transform.position;
        transform.Translate(0, 0, projectileSpeed * Time.deltaTime);

        RaycastHit2D[] hits = Physics2D.RaycastAll(bulletPrevPos, (transform.position - bulletPrevPos).normalized, (transform.position - bulletPrevPos).magnitude);
        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].collider.gameObject.name);
        }
        Debug.DrawLine(transform.position, bulletPrevPos);
    }

}
