using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject landEffect;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    //this method gets triggered when player collides with other rigidbodies
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {

            if (rb.velocity.y <= 0)
            {
                jumpForce = grav * jumpHeight;
                rb.velocity = new Vector2(0f, jumpForce);
                ScoreManager.instance.IncreaseScore();
                Camera.main.backgroundColor = other.gameObject.GetComponent<SpriteRenderer>().color;
                DestroyAndCreate(other);
                grav += 0.01f;
                LandOnObstacleEffect();
            }

        }
    }


    //to play LandingEffect animation 
    private void LandOnObstacleEffect()
    {        
        Destroy(Instantiate(landEffect, transform.position, Quaternion.identity),0.5f);
    }


    //this method is used to set active true or false for obstacle prefabs. called in OnTriggerEnter2D()
    void DestroyAndCreate(Collider2D obstacle)
    {
        //Destroy(obstacle.gameObject);         //creating and destroying assets takes up lot of cpu power in mobiles hence actiavte or deactivate them instead
        obstacle.gameObject.SetActive(false);
        ObstacleSpawner.instance.CreateObstacle();
    }


    //to keep the player moving in y-axis with consistent velocity. called in update() 
    void AdddGravity()
    {
        rb.velocity = new Vector2(0, rb.velocity.y - (grav * grav));
    }

    //updates on every frame
    void Update()
    {
        AdddGravity();
        GetInput();
        MovePlayer();
        CheckPlayerDeadAndRestart();
    }

    //this method is to move the player corresponding to the distance with which the mouse pointer would move
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

    //check when mousebutton is clicked
    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true; //true unti mousebutton is lifted
            mouseStartPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)); //the position where the mousebutton is clicked first
            playerPos = transform.position;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    void CheckPlayerDeadAndRestart()
    {
        if (transform.position.y < Camera.main.transform.position.y - 15)
        {
            //Debug.Log("Player is out of screen now");
            GameManager.instance.GameOver();
        }
    }
}
