using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Transform bulletSpawn;
    public float fireRate = 0.5f;

    private float nextFire;
    private float myTime;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = GetComponent<ObjectPool>().GetPooledObject();

            if (bullet == null) return;
            bullet.transform.position = bulletSpawn.transform.position;
            bullet.transform.rotation = bulletSpawn.transform.rotation;
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bullet.GetComponent<Mover>().speed;
            bullet.SetActive(true);
        }
    }

}
