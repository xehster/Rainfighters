using UnityEngine;

public class BulletView : MonoBehaviour
{
    private float projectileSpeed;
    
    public void SetBulletData(float speed)
    {
        projectileSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
    }
}
