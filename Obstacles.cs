using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles:MonoBehaviour
{
    internal int points;

    public virtual int GetObstaclePoints()
    {
        return points;
    }

    public virtual void CollectObstacle()
    {
        gameObject.SetActive(false);
    }


}
