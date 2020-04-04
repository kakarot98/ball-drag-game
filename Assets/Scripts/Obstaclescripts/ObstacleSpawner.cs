using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject obstaclePrefab = default;

    [SerializeField]
    private float obstacleHeight = 1f, obstacleWidth = 2f;
    int index = 0;

    [SerializeField]
    int minX = -5, maxX = 6;

    public static ObstacleSpawner instance = null;

    List<GameObject> obstacleList = new List<GameObject>();

    float hue;


    void Start()
    {
        AddObstaclesToList();

        if (instance == null)
        {
            instance = this;
        }

        for (int i = 0; i < 5; i++)
        {
            CreateObstacle();
        }
        SetBackgroundColor();
    }

    void SetBackgroundColor()
    {
        hue = Random.Range(0f, 1f);
        Camera.main.backgroundColor = Color.HSVToRGB(hue, 0.6f, 0.8f);
    }

    void AddObstaclesToList()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject obstacleToAdd = Instantiate(obstaclePrefab);
            obstacleToAdd.SetActive(false);
            obstacleList.Add(obstacleToAdd);
        }
    }


    GameObject GetObstacle()
    {
        GameObject obstacleToBeActive;
        for (int i = 0; i < obstacleList.Count; i++)
        {
            if (!obstacleList[i].activeInHierarchy)
            {
                obstacleToBeActive = obstacleList[i];
                return obstacleToBeActive;
            }
        }
        return null;
    }

    public void CreateObstacle()
    {
        int randomPositionX;
        if (index == 0)
        {
            randomPositionX = 0;
        }
        else
        {
            randomPositionX = Random.Range(minX, maxX);
        }
        Vector2 newPosition = new Vector2(randomPositionX, index * 5);

        //GameObject obstacle = Instantiate(obstaclePrefab, newPosition, Quaternion.identity);
        //Instead of creating many obstacles and delting, create 5 in a list, set them active and deactivate them accordingly

        GameObject obstacle = GetObstacle();
        SetColorOfObstacle(obstacle);
        obstacle.SetActive(true);
        
        obstacle.transform.position = newPosition;
        obstacle.transform.rotation = Quaternion.identity;        
        obstacle.transform.SetParent(transform);
        obstacle.transform.localScale = new Vector2(obstacleWidth, obstacleHeight);        
        index++;
    }


    void SetColorOfObstacle(GameObject obstacle)
    {

        if (Random.Range(0, 3) != 0)
        {

            hue += 0.11f;
            if (hue >= 1)
            {
                hue -= 1f;
            }
            obstacle.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(hue,0.6f,0.8f);
        }
    }
}
