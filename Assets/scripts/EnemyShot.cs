using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float fireRate;
    public GameObject shot;

    private ObjectPool bullets;
    private float myTime;
    private float nextFire;

    // Use this for initialization
    void Start ()
    {
        bullets = new ObjectPool();
        bullets.poolAmmount = 10;
        bullets.growth = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Time.time > nextFire)
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
