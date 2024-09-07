using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
