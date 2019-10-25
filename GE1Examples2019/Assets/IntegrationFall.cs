using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegrationFall : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    Vector3 accel = new Vector3(0, -9.8f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float time = 0;

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y >= 0)
        {
            velocity +=  accel * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
            time += Time.deltaTime;
        }
        else
        {
            Debug.Log("Integration time: " + time);
        }
        
    }
}
