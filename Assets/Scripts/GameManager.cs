using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Color> availableColors = new List<Color>();
    public TMP_Text scoreText;
    public TMP_Text ballsLeftText;
    public int score = 0;
    public int bubblesLeft = 20;

    // Singleton
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateAvailableColors();
        UpdateBallsLeft();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Palle rimaste: " + bubblesLeft);
        if (bubblesLeft == 0)
            StopGame();
    }

    public void UpdateAvailableColors()
    {
        // Pulisce la lista dei colori disponibili
        availableColors.Clear();

        // Trova tutti i nemici attivi nella scena
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

        // Aggiunge i colori dei nemici attivi alla lista dei colori disponibili
        foreach (Enemy enemy in enemies)
        {
            if (!availableColors.Contains(enemy.enemyColor))
            {
                availableColors.Add(enemy.enemyColor);
            }
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        Debug.Log("Il punteggio è " + score);
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateBallsLeft()
    {
        ballsLeftText.text = bubblesLeft + " Palle Rimaste";
    }

    public void StopGame()
    {
        Time.timeScale = 0f;  // Ferma il gioco
        Debug.Log("Il gioco è stato fermato!");
    }
}
