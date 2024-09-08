using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject); //TODO Considerare se ha senso mantenere tra le scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

        // Move the enemy left and right within a certain distance
        // MoveEnemies();

    }

    void MoveEnemies()
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

    public void RemoveEnemy(GameObject ball)
    {
        enemyCount--;

        if (enemyCount <= 0)
        {
            Debug.Log("Tutti i nemici sono stati distrutti");
            GameManager.Instance.StopGame();
        }
    }
}
