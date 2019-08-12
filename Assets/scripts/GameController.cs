using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform playerShip;
    public float spawnRate;
    public float startWait;
    public float waveWait;
    public float spawnWait;

    private float nextSpawn = 0.5f;
    public int score = 0;
    private float myTime;

    public Text ScoreText;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
        UpdateScore(0);
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < GetComponent<ObjectPool>().poolAmmount; i++)
            {
                GameObject clone = GetComponent<ObjectPool>().GetPooledObject();
                if (clone != null)
                {
                    clone.transform.position = new Vector3(Random.Range(-6f, 6f), 0, 20);
                    clone.GetComponent<Health>().RestoreHealth();
                    clone.GetComponent<EnemyAim>().SetPlayerShip(playerShip);
                    clone.GetComponent<EnemyShot>().fire = true;
                    clone.SetActive(true);
                    yield return new WaitForSeconds(spawnWait);
                }
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void UpdateScore (int addScore)
    {
        score += addScore;
        ScoreText.text = "Score: " + score.ToString().PadLeft(7, '0');
    }
}
