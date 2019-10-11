using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    // Start is called before the first frame update
    void OnEnable()
    {
        //StartCoroutine(ShootingCoroutine());
    }

    public int fireRate = 2;
    float ellapsed = float.MaxValue;
    

    System.Collections.IEnumerator ShootingCoroutine()
    {
        float toPass = 1.0f / fireRate;
        while (true)
        {
            Debug.Log("Shooting!");
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            yield return new WaitForSeconds(toPass);

        }
    }

    Coroutine cr;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            cr = StartCoroutine(ShootingCoroutine());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(cr);
        }
        
        // Without coroutines
        /*float toPass = 1.0f / fireRate;
        ellapsed += Time.deltaTime;
        if (Input.GetAxis("Fire1") == 1 && ellapsed > toPass)
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            ellapsed = 0;
        }
        */
        
    }
}
