using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public Transform shotSpawn;
    public float fireRate;
    public bool fire = true;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("Fire", Random.Range(1, 3), fireRate);
    }

    // Update is called once per frame
    void Fire ()
    {
        if (!fire)
            return;
        GameObject bullet = GetComponent<ObjectPool>().GetPooledObject();
        if (bullet == null) return;
        bullet.transform.position = shotSpawn.position;
        bullet.transform.rotation = shotSpawn.rotation;
        bullet.GetComponent<Rigidbody>().velocity = shotSpawn.forward * bullet.GetComponent<Mover>().speed;
        bullet.SetActive(true);
    }
}
