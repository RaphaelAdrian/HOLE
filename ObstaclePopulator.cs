using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePopulator : MonoBehaviour
{
    public List<GameObject> obstacleToPool;
    public List<GameObject> obstaclePool = new List<GameObject>();
    public int size;
    public Vector2 horizontalLimit;
    public Vector2 verticalLimit;
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            int index = i % 26;
            Debug.Log(index);
            obstaclePool.Add(Instantiate(obstacleToPool[index], transform));
            obstaclePool[i].SetActive(false);
        }
        SpawnLevel();

    }

    public void SpawnLevel()
    {
        for (int i = 0; i < size; i++)
        { 
            SpawnObstacles();
        }
    }
    public GameObject SpawnObstacles()
    {
        GameObject objectToReturn;
        if (obstaclePool.Count > 0)
        {
            objectToReturn = obstaclePool[0];
            obstaclePool.RemoveAt(0);
        }
        else
        {
            objectToReturn = Instantiate(obstacleToPool[0],transform);
        }

        objectToReturn.SetActive(true);
        objectToReturn.transform.position = GetRandomPosition();
        return objectToReturn;
    }

    public void ReturnObject(GameObject objectToReturn)
    {
        obstaclePool.Add(objectToReturn);
        objectToReturn.SetActive(false);
    }

    public Vector3 GetRandomPosition()
    { 
        return new Vector3(Random.Range(horizontalLimit.x, horizontalLimit.y), 1f, Random.Range(verticalLimit.x, verticalLimit.y));
    }
}


