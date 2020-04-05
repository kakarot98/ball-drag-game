using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{


    Vector2 startPositionObstacle, targetPositionObstacle;
    //public float smoothTime = 0.01f;
    float randomX;

    Vector2 velocity = Vector2.zero;

    

    public void ChangePositionObstacle()
    {
        
        targetPositionObstacle = transform.position;
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            randomX = 10;
        }
        else {
            randomX = -10;
        }

        startPositionObstacle = new Vector2(targetPositionObstacle.x + randomX, transform.position.y);
        transform.position = startPositionObstacle;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(targetPositionObstacle, transform.position) > 0.01f) {
            //MovetoTargetPosition();
            transform.position = Vector2.MoveTowards(transform.position, targetPositionObstacle, 25 * Time.deltaTime);
        }
    }

    //void MovetoTargetPosition()
    //{
        //transform.position = Vector2.SmoothDamp(transform.position, targetPositionObstacle, ref velocity, smoothTime);
    //}
}
