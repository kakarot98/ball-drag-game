using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject target;

    
    public float smoothTime = 0.3f;    //smoothness with which camera moves. change and set according to need from the inspector
    public float yOffset;
    Vector2 velocity = Vector2.zero;

    // Update is called once per frame
    void Update()
    {

        Vector2 targetPos = target.transform.TransformPoint(new Vector3(0, yOffset));   //setting an offset or distance where the camera should be positioned

        if (targetPos.y < transform.position.y)
        {         //checking if the player is higher than the camera
            return;
        }

        //set the targetPos to where camera must be positioned and then set the position to the camera.transform
        targetPos = new Vector2(0, targetPos.y);
        transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        
    }
}
