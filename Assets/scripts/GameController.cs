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
    private int currentWave = 1;

    public Text ScoreText;
    public Text GameOverText;
    public Text RestartGameText;

    private void Start()
    {
        gameOver = false;
        restart = false;
        GameOverText.text = "";
        RestartGameText.text = "";
        currentWave = 1;
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
        GameOverText.text = $"{currentWave}st Wave Incomming";        
        while (!gameOver)
        {
            yield return new WaitForSeconds(startWait);
            GameOverText.text = "";
            for (int i = 0; i < GetComponent<ObjectPool>().poolAmmount; i++)
            {
                GameObject clone = GetComponent<ObjectPool>().GetPooledObject();
                if (clone != null)
                {
                    clone.transform.position = new Vector3(Random.Range(-6f, 6f), 0, 21);
                    clone.GetComponent<Health>().RestoreHealth();
                    clone.GetComponent<EnemyAim>().SetPlayerShip(playerShip);
                    clone.SetActive(true);
                    if (!playerShip.GetComponent<Health>().IsAlive())
                        GameOver();
                    yield return new WaitForSeconds(spawnWait);
                }
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restart = true;
                RestartGameText.text = "Press ENTER to start a new Game";
            }
            else
            {
                switch (++currentWave)
                {
                    case 2: GameOverText.text = $"{currentWave}nd Wave Incomming"; break;
                    case 3: GameOverText.text = $"{currentWave}rd Wave Incomming"; break;
                    default: GameOverText.text = $"{currentWave}th Wave Incomming"; break;
                }
                
            }

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
        GameOverText.text = "Game Over";
    }
}
