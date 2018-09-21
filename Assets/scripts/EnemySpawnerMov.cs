using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerMov : MonoBehaviour
{

    public Boundary boundary;
    public GameObject enemyObject;
    public float spawnRate;
    public float speed;

    private float nextSpawn = 0.5f;
    private float myTime;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), 0, transform.position.z);
	    if (transform.position.x <= boundary.xMin || transform.position.x >= boundary.xMax)
	        speed *= -1;

	    myTime += Time.deltaTime;

	    if (myTime > nextSpawn)
	    {
	        nextSpawn += myTime + spawnRate;

	        GameObject clone = Instantiate(enemyObject, transform.position, transform.rotation);

	        nextSpawn -= myTime;
	        myTime = 0.0f;
	    }
	}
}
