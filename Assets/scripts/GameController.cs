using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform playerShip;
    public float spawnRate;
    public float startWait;
    public float waveWait;
    public float spawnWait;
    public int score = 0;

    private float nextSpawn = 0.5f;
    private float myTime;
    private bool gameOver;
    private bool restart;

    public Text ScoreText;
    public Text GameOverText;
    public Text RestartGameText;

    private void Start()
    {
        gameOver = false;
        restart = false;
        GameOverText.text = "";
        RestartGameText.text = "";
        StartCoroutine(SpawnEnemies());
        UpdateScore(0);
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(startWait);
        while (!gameOver)
        {
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
                    if (!playerShip.GetComponent<Health>().IsAlive())
                        GameOver();
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

    private void GameOver ()
    {
        gameOver = true;
        restart = true;
        GameOverText.text = "Game Over";
        RestartGameText.text = "Press ENTER to start a new Game";
    }
}
