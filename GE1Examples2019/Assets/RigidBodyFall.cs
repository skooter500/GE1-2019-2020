using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyFall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (transform.position.y <=0)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Rigid body time" + time);
        }
    }
}
