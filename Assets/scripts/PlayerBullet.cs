using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject shot;
    public Transform bulletSpawn;
    public float fireRate;

    private float nextFire;
    private float myTime;

    void Update()
    {
        //myTime += Time.deltaTime;

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, bulletSpawn.position, bulletSpawn.rotation);

        }
    }

}
