using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 5.0f;
    public float rotSpeed = 180.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);

        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed, 0);
        
    }
}
