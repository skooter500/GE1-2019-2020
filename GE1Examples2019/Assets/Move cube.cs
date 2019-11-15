using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecube : MonoBehaviour
{
    //Script moves one cube towards a target cube
    public Transform target;
    public float time = 5;
    public float speed = 5;
    public float t;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 toTarget = target.position - transform.position;
        float distance = toTarget.magnitude;
        speed = distance / time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toTarget = target.position - transform.position;
        toTarget.Normalize();
        //distance = toTarget.magnitude;
        t += Time.deltaTime;
        transform.position += toTarget * speed * t;
    }
}
