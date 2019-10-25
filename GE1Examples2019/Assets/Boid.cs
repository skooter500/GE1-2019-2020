using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 force;
    public float mass = 1;
    public float maxSpeed = 10;

    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + force);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + velocity);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + acceleration);

    }



    // Update is called once per frame
    void Update()
    {
        force = CalculateForce();
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        if (velocity.magnitude > 0)
        {
            transform.forward = velocity;
        }

    }

    private Vector3 CalculateForce()
    {
        Vector3 desired = target.position - transform.position;
        desired.Normalize();
        desired *= maxSpeed;
        return desired - velocity;
    }
}
