using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

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
    }

    public void SetPlayerShip (GameObject _playerShip)
    {
        playerShip = _playerShip;
    }
}
