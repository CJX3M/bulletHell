using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public Transform shotSpawn;
    public float fireRate;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("Fire", 0, fireRate);
    }

    // Update is called once per frame
    void Fire ()
    {
            GameObject bullet = GetComponent<ObjectPool>().GetPooledObject();
            if (bullet == null) return;
            bullet.transform.position = shotSpawn.position;
            bullet.transform.rotation = shotSpawn.rotation;
            bullet.SetActive(true);
    }
}
