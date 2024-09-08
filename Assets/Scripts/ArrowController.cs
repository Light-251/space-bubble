using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Transform spawnPoint;
    public float shootForce = 15f;
    private GameObject currentBubble;
    private bool isBubbleInstatiated = false;
    public float rotationSpeed = 250f; // Velocità della rotazione della Freccia
    public GameObject bubblePrefab; // Proiettile
    public Transform firePoint; // Oggetto usato per istanziare il Proiettile
    public Transform arrowTransform;

    // Range di movimento della Freccia
    public float maxRotation = 155.901f;
    public float minRotation = 29.628f;

    public float bubbleSpeed = 15f; // Velocità del Proiettile
    public float shootDelay = 0.35f; // Delay in secondi tra uno sparo e l'altro
    private float nextShootTime = 0f; // Tempo del prossimo sparo consentito

    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Bubble"), LayerMask.NameToLayer("Bubble"));
    }

    void Update()
    {
        // Controllo della direzione della Freccia
        float rotationZ = arrowTransform.eulerAngles.z;
        float horizontalInput = Input.GetAxis("Horizontal");

        if ((rotationZ > maxRotation && horizontalInput > 0) || (rotationZ < minRotation && horizontalInput < 0))
        {
            float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -rotation);
        }

        // Istanziamento della palla sulla punta della freccia
        if (!isBubbleInstatiated)
        {
            InstantiateBubble();
            isBubbleInstatiated = true;
        }
        else
        {
            currentBubble.transform.position = spawnPoint.position;
        }

        // Sparo della Palla
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextShootTime && currentBubble != null)
        {
            ShootBubble();
            nextShootTime = Time.time + shootDelay;
            isBubbleInstatiated = false;
        }
    }

    void ShootBubble()
    {
        Rigidbody2D rb = currentBubble.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * shootForce, ForceMode2D.Impulse);
        currentBubble = null;
    }

    void InstantiateBubble()
    {
        currentBubble = Instantiate(bubblePrefab, spawnPoint.position, Quaternion.identity);
    }
}