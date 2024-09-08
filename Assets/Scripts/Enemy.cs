using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Modificare lo sprite in base al colore
public class Enemy : MonoBehaviour
{
    public Color[] possibleColors;
    public Color enemyColor; // TODO: Configurare l'assegnazione del colore in modo randomico allo spawn
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        AssignRandomColor();

        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.AddEnemy();
        }
        else
        {
            Debug.LogError("EnemyController not found in the scene");
        }
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            BallController ballController = collision.gameObject.GetComponent<BallController>();
            EnemyManager.Instance.RemoveEnemy(collision.gameObject);

            if (ballController.ballColor == enemyColor)
                GameManager.Instance.AddScore(15);
            else
                GameManager.Instance.AddScore(10);

            Destroy(gameObject);
        }
    }

    void AssignRandomColor()
    {
        enemyColor = possibleColors[Random.Range(0, possibleColors.Length)];
        enemyColor.a = 1;
        spriteRenderer.color = enemyColor;
    }

    void OnDestroy()
    {
        GameManager.Instance.UpdateAvailableColors();
    }
}