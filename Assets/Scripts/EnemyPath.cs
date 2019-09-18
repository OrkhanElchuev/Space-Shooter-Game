﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2.5f;

    private int wayPointIndex = 0; 

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    // Handling Movement of Enemy
    private void EnemyMovement()
    {
        // Go through the last Waypoint
        if (wayPointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[wayPointIndex].position;
            var movementFrame = moveSpeed * Time.deltaTime;
            // Smoothly move towards targeted waypoint's position 
            transform.position = Vector2.MoveTowards
                (transform.position, targetPosition, movementFrame);
            // When arrived to targeted waypoint increment the index
            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        // When arrived to the last waypoint destroy itself
        else
        {
            Destroy(gameObject);
        }
    }
}
