using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject shot;
    public Transform bulletSpawn;
    public float fireRate;
    public ObjectPool bullets;

    private float nextFire;
    private float myTime;

    void Start()
    {
    }

    void Update()
    {
        //myTime += Time.deltaTime;

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = bullets.GetPooledObject();

            if (bullet == null) return;

            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }

}
