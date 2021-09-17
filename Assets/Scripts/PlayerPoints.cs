using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    public Text testTest;
    public TextMeshProUGUI textPoints;
    public float initialPoints = 0f;
    public float timeFactor = 1f;
    public float collectableFactor = 200f;
    public float destructibleFactor = 10f;

    private int destructibleDestroyed = 0;

    private float GameTime;

    // Start is called before the first frame update
    void Start()
    {
        GameTime = 0;
    }

    public void AddDestroyed()
    {
        destructibleDestroyed ++;
    }

    public float ShowDestroyedPoints()
    {
        return destructibleFactor * destructibleDestroyed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameTime += Time.deltaTime;
        testTest.text = TotalPoints().ToString();
        textPoints.text = "Total Points: " + TotalPoints().ToString();
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
            return 0000;
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
        return CollectablePoints() + ShowDestroyedPoints();
    }
}
