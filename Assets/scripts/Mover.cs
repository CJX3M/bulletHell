using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    public int points;

	// Use this for initialization
	void Start ()
	{
        if (gameObject.tag == "Enemie")
	        GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
