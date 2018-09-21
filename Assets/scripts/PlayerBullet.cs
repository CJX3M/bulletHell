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
        myTime += Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + fireRate;
            GameObject clone = Instantiate(shot, bulletSpawn.position, bulletSpawn.rotation) as GameObject;

            nextFire -= myTime;
            myTime = 0.0f;
        }
    }

}
