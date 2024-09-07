using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyController enemyController = FindObjectOfType<EnemyController>();

        if (enemyController != null)
        {
            enemyController.AddEnemy();
        }
        else
        {
            Debug.LogError("EnemyController non trovato nella scena");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bubble"))
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        EnemyController enemyController = FindAnyObjectByType<EnemyController>();

        if (enemyController != null)
        {
            enemyController.RemoveEnemy();
        }
        else
        {
            Debug.LogError("EnemyController non trovato nella scena");
        }
    }
}