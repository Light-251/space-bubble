using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Modificare lo sprite in base al colore
public class BallController : MonoBehaviour
{
    public Color ballColor;
    // public Color[] possibleColors;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        AssignRandomColor();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AssignRandomColor()
    {
        if (GameManager.Instance.availableColors.Count > 0)
        {
            ballColor = GameManager.Instance.availableColors[Random.Range(0, GameManager.Instance.availableColors.Count)];
            ballColor.a = 1;
            spriteRenderer.color = ballColor;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Controlla se la palla ha toccato il bordo superiore
        if (collision.gameObject.CompareTag("TopBorder")
            || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); // Distrugge la palla
        }
    }

    void OnDestroy()
    {
        GameManager.Instance.bubblesLeft--;
        GameManager.Instance.UpdateBallsLeft();
    }
}
