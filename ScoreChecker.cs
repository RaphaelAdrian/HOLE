using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChecker : MonoBehaviour
{
    public ScoreManager scoreManager;
    public ObstaclePopulator obstaclePopulator;
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Obstacles>())
        {
            Obstacles obstacle = other.GetComponent<Obstacles>();
            scoreManager.AddScore(obstacle.GetObstaclePoints());
            obstaclePopulator.ReturnObject(other.gameObject);
            obstaclePopulator.SpawnObstacles();
        }
    }
}
