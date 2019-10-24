using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public Transform target;

    //public float speed = 5;
    public float time = 5;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 toTarget = target.position - transform.position;
        float dist = toTarget.magnitude;
        speed = dist / time;

    }

    float speed;

    // Update is called once per frame
    float t = 0;
    void Update()
    {
        Vector3 toTarget = target.position - transform.position;
        toTarget.Normalize();
        t += Time.deltaTime;
        transform.position += toTarget * speed * Time.deltaTime;
        Debug.Log(t);
    }
}
