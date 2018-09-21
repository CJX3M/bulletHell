using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

	// Use this for initialization
	void Start ()
	{
	    GetComponent<Rigidbody>().velocity = transform.forward * speed * -1;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
