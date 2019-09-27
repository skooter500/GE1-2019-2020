using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(speed * Time.deltaTime, 0, 0);
        Vector3 p = transform.position;
        p.x += speed * Time.deltaTime;
        transform.position = p;
        p += Vector3.right * speed * Time.deltaTime;
        transform.position = p;

    }
}
