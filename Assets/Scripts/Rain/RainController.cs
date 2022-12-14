using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RainController : MonoBehaviour
{
    public float projectileSpeed = 10f;
    private Vector3 bulletPrevPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RainSpeedIncrease());
    }

    // Update is called once per frame
    void Update()
    {
        RainRayShooting();
    }
    
    void RainRayShooting()
    {
        transform.Translate(Vector2.down * Time.deltaTime * projectileSpeed);
        if (transform.position.y < -15f)
        {
            Destroy(gameObject);
        }

        bulletPrevPos = transform.position;

        RaycastHit2D[] hits = Physics2D.RaycastAll(bulletPrevPos, (transform.position - bulletPrevPos).normalized, (transform.position - bulletPrevPos).magnitude);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.CompareTag("Player1"))
            {
                hits[i].collider.gameObject.GetComponent<PlayerController>().HitByRay();
                Destroy(hits[i].collider.gameObject);
            }
            
            if (hits[i].collider.gameObject.CompareTag("Player2"))
            {
                hits[i].collider.gameObject.GetComponent<Player2Controller>().HitByRay();
                Destroy(hits[i].collider.gameObject);
            }

        }
        Debug.DrawLine(transform.position, bulletPrevPos);
    }
    

    IEnumerator RainSpeedIncrease()
    {
        projectileSpeed += 10;
        yield return new WaitForSeconds(5);
        StartCoroutine(RainSpeedIncrease());
    }

}
