using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public float holdDistance = 1;
    public float maximumVelocity = 30;
    public float powerFactor = 40;

    GameObject pickedUp = null;
    Transform camera;

    public bool isPhisGun = false;

    // Start is called before the first frame update
    void Start()
    {
        if (camera == null)
        {
            camera = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (pickedUp == null)
            {
                RaycastHit rch;

                if (Physics.Raycast(camera.position, camera.forward, out rch))
                {
                    if (rch.collider.gameObject.tag != "groundPlane")
                    {
                        pickedUp = rch.collider.gameObject;
                        holdDistance = Vector3.Distance(camera.position, pickedUp.transform.position);
                    }

                }
            }
            else
            {
                Vector3 holdPos = camera.position + camera.forward * holdDistance;
                Vector3 toHoldPos = holdPos - pickedUp.transform.position;
                toHoldPos *= powerFactor;
                toHoldPos = Vector3.ClampMagnitude(toHoldPos, maximumVelocity);
                pickedUp.transform.GetComponent<Rigidbody>().velocity = toHoldPos;
            }
        }
        else
        {
            pickedUp = null;
        }
    }
}
