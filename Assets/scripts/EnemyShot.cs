using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float fireRate;
    public GameObject shot;

    private float myTime;
    private float nextFire;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot,  gameObject.transform.position, gameObject.transform.rotation);
        }

    }
}
