﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float padding = 0.8f;
    [SerializeField] float projectileSpeed = 10.0f;
    [SerializeField] GameObject laserObject;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetMoveLimits();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Shoot();
    }

    // Method for player shooting
    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Quaternion corresponds to "no rotatition" for instantiated object
            GameObject laser = Instantiate(laserObject, transform.position,
                Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        }   
    }

    // Setting boundaries for moving the object
    private void SetMoveLimits()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Frame Rate independent 2D object moving function
    private void MovePlayer()
    {
        // Horizontal and Vertical allows moving object with WASD or arrows
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        // Getting X and Y positions, clamping Horizontal and Vertical movement
        // to avoid leaving the boundaries of screen
        var newXPosition = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPosition = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        // Setting X and Y positions to the object
        transform.position = new Vector2(newXPosition, newYPosition);
    }
}
