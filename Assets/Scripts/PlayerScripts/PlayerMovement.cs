using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    float jumpForce;
    public float grav = 1f;
    public float jumpHeight = 10f;
    bool isDragging = false;
    Vector2 mouseStartPos, playerPos, mousePos;
    public float leftBound, rightBound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {

            if (rb.velocity.y <= 0)
            {
                jumpForce = grav * jumpHeight;
                rb.velocity = new Vector2(0f, jumpForce);
                DestroyAndCreate(other);
            }

        }
    }

    void DestroyAndCreate(Collider2D obstacle) {
        //Destroy(obstacle.gameObject);         //This would take up a lot of cpu power
        obstacle.gameObject.SetActive(false);
        ObstacleSpawner.instance.CreateObstacle();
    }


    void AdddGravity()
    {
        rb.velocity = new Vector2(0, rb.velocity.y - (grav * grav));
    }

    void Update()
    {
        AdddGravity();
        GetInput();
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (isDragging)
        {
            mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = new Vector2(playerPos.x + (mousePos.x - mouseStartPos.x), transform.position.y);

        }

        if (transform.position.x >= rightBound)
        {
            transform.position = new Vector2(rightBound, transform.position.y);
        }

        if (transform.position.x <= leftBound)
        {
            transform.position = new Vector2(leftBound, transform.position.y);
        }

    }

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            mouseStartPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            playerPos = transform.position;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
