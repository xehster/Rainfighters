using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class RainCreation : MonoBehaviour
{
    public RainController rainController;

    private Vector2 firePointPosition;
    private float x;
    private float y;
    private float rainSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Rain());
        StartCoroutine(RainIntencity());
    }

    // Update is called once per frame
    void Update()
    {
        RandomPositionGenerator();

    }
    
    IEnumerator Rain()
    {
        yield return new WaitForSeconds(rainSpeed);
        var bullet = Instantiate(rainController, firePointPosition, Quaternion.identity);
        StartCoroutine(Rain());
    }

    IEnumerator RainIntencity()
    {
        yield return new WaitForSeconds(5);
        if (rainSpeed >= 0.01f)
        {
            rainSpeed /= 2f;
            StartCoroutine(RainIntencity());
        }
    }

    void RandomPositionGenerator()
    {
        x = Random.Range(-30f, 30f);
        y = Random.Range(10f, 15f);
        
        firePointPosition = new Vector2(x, y);
    }
}
