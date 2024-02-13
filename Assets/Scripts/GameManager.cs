using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text infoText;
    public Text counterText;
    public Text timerText;
    public GameObject enemyPrefab;

    private int destroyedCount = 0;
    private float timer = 0f;
    private bool gameRunning = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        infoText.text = "Presiona una tecla para iniciar";
        counterText.text = "Objetos destruidos: 0";
        timerText.text = "Tiempo: 00:00:00";
    }

    void Update()
    {
        if (gameRunning)
        {
            timer += Time.deltaTime;
            UpdateTimerText();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !gameRunning)
        {
            StartGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gameRunning)
        {
            StopGame();
        }
    }

    void StartGame()
    {
        infoText.text = "";
        gameRunning = true;
        InvokeRepeating("SpawnEnemy", 2f, 3f);
    }

    void StopGame()
    {
        gameRunning = false;
        CancelInvoke("SpawnEnemy");
        infoText.text = "Presiona Esc para detener el programa";
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        int milliseconds = Mathf.FloorToInt((timer * 100f) % 100f);

        timerText.text = string.Format("Tiempo: {0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void IncrementDestroyedCount()
    {
        destroyedCount++;
        counterText.text = "Objetos destruidos: " + destroyedCount;
    }

    void SpawnEnemy()
    {
        float randomY = Random.Range(-4f, 4f);
        Vector2 spawnPosition = new Vector2(10f, randomY);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
