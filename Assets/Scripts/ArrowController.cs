using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

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

    // Start is called before the first frame update
    void Start()
    {
        // Disabilita la collisione tra tutti gli oggetti con lo stesso tag "Bubble"
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Bubble"), LayerMask.NameToLayer("Bubble"));

    }

    // Update is called once per frame
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

        // Sparo della Palla
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextShootTime)
        {
            shootBubble();
            nextShootTime = Time.time + shootDelay;
        }
    }
    void shootBubble()
    {
        GameObject bubble = Instantiate(bubblePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bubble.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bubbleSpeed;
    }
}
