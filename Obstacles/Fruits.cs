using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : Obstacles
{
    public FruitSize fruitSize;
    private int[] score = {3, 7, 10 };
    public void Awake()
    {   
        points = score[(int)fruitSize];
    }

    public override int GetObstaclePoints()
    {
        return base.GetObstaclePoints();
    }

    public override void CollectObstacle()
    {
        base.CollectObstacle();
    }
}
public enum FruitSize {Small,Medium,Large}