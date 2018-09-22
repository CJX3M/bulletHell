using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public Transform bulletSpawn;
    public GameObject shot;

    private float myTime;
    private float nextFire;
    private GameObject playerShip;    

	// Use this for initialization
	void Start ()
	{
	    GetComponent<Rigidbody>().velocity = transform.forward * -speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
        Vector3 toTarget = playerShip.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.down, -toTarget);

        myTime += Time.deltaTime;

        if (myTime > nextFire)
        {
            nextFire = myTime + fireRate;
            GameObject clone = Instantiate(shot, bulletSpawn.position, bulletSpawn.rotation) as GameObject;

            nextFire -= myTime;
            myTime = 0.0f;
        }
    }

    public void SetPlayerShip (GameObject _playerShip)
    {
        playerShip = _playerShip;
    }
}
