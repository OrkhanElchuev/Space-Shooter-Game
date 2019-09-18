using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    // Frame Rate independent 2D object moving function
    private void MovePlayer()
    {
        // Horizontal provides functionality for moving object with AD or arrows
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPosition = transform.position.x + deltaX;
        // Vertical provides functionality for moving object with WS or arrows
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPosition = transform.position.y + deltaY;
        
        transform.position = new Vector2(newXPosition, newYPosition);
    }
}
