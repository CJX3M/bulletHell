using UnityEngine;

public class EnemySpawnerMov : MonoBehaviour
{

    public Boundary boundary;
    public GameObject playerShip;
    public float spawnRate;
    public float speed;

    private float nextSpawn = 0.5f;
    private float myTime;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), 0, transform.position.z);
	    if (transform.position.x <= boundary.xMin || transform.position.x >= boundary.xMax)
	        speed *= -1;

	    if (Time.time > nextSpawn)
	    {
            nextSpawn = Time.time + spawnRate;

            GameObject clone = GetComponent<ObjectPool>().GetPooledObject();
            if (clone == null || clone.activeInHierarchy) return;
            clone.transform.position = transform.position;
            clone.GetComponent<Health>().RestoreHealth();
            //clone.GetComponent<EnemyMovement>().SetPlayerShip(playerShip);
            clone.SetActive(true);
        }
	}
}
