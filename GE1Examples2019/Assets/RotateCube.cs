using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        /*Quaternion q = Quaternion.AngleAxis(90, Vector3.up);
        Quaternion q1 = Quaternion.AngleAxis(90, Vector3.right);
        transform.rotation = q * q1;
        Vector3 v = new Vector3(0, 0, 1);
        v = q1 * v;
        Debug.Log(v);
        //Debug.Log(transform.forward);
        */
        from = transform.rotation;
        Vector3 totarget = target.transform.position - transform.position;
        to = Quaternion.LookRotation(totarget);

    }

    Quaternion from;
    Quaternion to;
    float t;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger!");
    }
    public void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger stay!");
    }
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exit!");
    }



    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(from, to, t);
        if (t < 1)
        {
            t += (Time.deltaTime / 5);
        }
                    
    }
}
