using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject obstaclePrefab;

    [SerializeField]
    private float obstacleHeight = 0.5f, obstacleWidth = 2f;
    int index = 0;

    [SerializeField]
    int minX = -5, maxX = 6;

    public static ObstacleSpawner instance = null;

    List<GameObject> obstacleList = new List<GameObject>();


    void Start()
    {
        AddObstaclesToList();

        if (instance == null) {
            instance = this;
        }

        for(int i = 0; i < 5; i++) {
            CreateObstacle();
        }
    }

    void AddObstaclesToList() {
        for (int i = 0; i < 5; i++) {
            GameObject obstacleToAdd = Instantiate(obstaclePrefab);
            obstacleToAdd.SetActive(false);
            obstacleList.Add(obstacleToAdd);
        }
    }


    GameObject GetObstacle() {
        GameObject obstacleToBeActive;
        for (int i = 0; i < obstacleList.Count; i++) {
            if (!obstacleList[i].activeInHierarchy) {
                obstacleToBeActive = obstacleList[i];
                return obstacleToBeActive;
            }
        }
        return null;
    }

    public void CreateObstacle() {
        int randomPositionX;
        if (index == 0) {
            randomPositionX = 0;
        }
        else {
            randomPositionX = Random.Range(minX, maxX);
        }
        Vector2 newPosition = new Vector2(randomPositionX, index * 5);

        //GameObject obstacle = Instantiate(obstaclePrefab, newPosition, Quaternion.identity);
        //Instead of creating many obstacles and delting, create 5 in a list, set them active and deactivate them accordingly

        GameObject obstacle = GetObstacle();
        obstacle.SetActive(true);
        obstacle.transform.position = newPosition;
        obstacle.transform.rotation = Quaternion.identity;        
        obstacle.transform.SetParent(transform);
        obstacle.transform.localScale = new Vector2(obstacleWidth, obstacleHeight);
        index++;
    }
}
