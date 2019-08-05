using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform playerShip;
    public float spawnRate;

    private float nextSpawn = 0.5f;
    private float myTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;

            GameObject clone = GetComponent<ObjectPool>().GetPooledObject();
            if (clone == null || clone.activeInHierarchy) return;
            clone.transform.position = new Vector3(Random.Range(-6f, 6f), 0, 20);
            clone.GetComponent<Health>().RestoreHealth();
            clone.GetComponent<EnemyAim>().SetPlayerShip(playerShip);
            clone.SetActive(true);
        }
    }
}
