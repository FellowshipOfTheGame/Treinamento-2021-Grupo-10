using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPoints : MonoBehaviour
{
    public Text testTest;
    public float initialPoints = 1000;
    public float timeFactor = 1;
    public float collectableFactor = 200;

    private float GameTime;

    // Start is called before the first frame update
    void Start()
    {
        GameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;
        testTest.text = TotalPoints().ToString();
    }

    public float ShowTime()
    {
        return GameTime;
    }

    // Return points related with the Time that the player
    // spend to win the game (more the time, minor the points)
    public float TimePoints()
    {
        // Get the time since the player start the Play Scene

        // Obtain the points from the formula using the timeFactor
        float points = initialPoints - ShowTime() * timeFactor;

        // Tests if the point is a negative number
        if (points < 0)
        {
            return 0;
        }
        else
        {
            return points;
        }
    }

    // Return points related with the Collectibles
    public float CollectablePoints()
    {
        float collected = (float)FindObjectOfType<ChariotCollision>().ShowCollectableCollected();

        return collected * collectableFactor;
    }

    // Return the total points of the player
    public float TotalPoints()
    {
        return CollectablePoints() + TimePoints();
    }
}
