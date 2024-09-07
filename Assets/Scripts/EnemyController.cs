using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 2f;
    public float moveDistance = 0.7f;
    private Vector3 startPos;
    private bool movingRight = true;
    public int enemyCount;
    public GameObject enemyPrefab;
    public float respawnDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= startPos.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= startPos.x - moveDistance)
                movingRight = true;
        }
    }

    public void AddEnemy()
    {
        enemyCount++;
    }

    public void RemoveEnemy()
    {
        enemyCount--;

        if (enemyCount <= 0)
        {
            Debug.Log("Tutti i nemici sono stati distrutti");
            StopGame();
        }
    }

    void StopGame()
    {
        Time.timeScale = 0f;  // Ferma il gioco
        Debug.Log("Il gioco è stato fermato!");
    }
}
