using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text gameOverText;
    public Text restartText;
    public Text createdByText;
    private int score;

    private bool gameOver;
    private bool restart;

    private AudioSource backgroundMusic;

    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        backgroundMusic.Play();

        score = 0;
        UpdateScore();

        gameOver = false;
        restart = false;

        gameOverText.text = "";
        restartText.text = "";
        createdByText.text = "";

        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        { if (Input.GetKeyDown (KeyCode.Return))
            {
                SceneManager.LoadScene("Main");
            }
        }

        if (Input.GetKeyDown (KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards [Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            { restartText.text = "Press 'ENTER' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();

        if (score >= 100)
        {
            createdByText.text = "YOU WIN!";
            gameOver = true;
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + score;
    }

    public void GameOver ()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}