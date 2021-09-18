using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject MenuScore;
    //public GameObject Collectible;
    public GameObject PowerUp;

    public Camera cam;

    private float screenLeft;
    private float screenRight;
    private float screenTop;
    private float screenBottom;

    private float scoreHalfWidth;
    private float scoreHalfHeigth;
    private float powerHalfWidth;
    private float powerHalfHeigth;

    private bool isScoreResized = false;
    private bool isPowerResized = false;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D colliderScore = MenuScore.GetComponent<BoxCollider2D>();
        BoxCollider2D colliderPower = PowerUp.GetComponent<BoxCollider2D>();

        scoreHalfWidth = colliderScore.size.x/2;
        scoreHalfHeigth = colliderScore.size.y / 2;
        powerHalfWidth = colliderPower.size.x/2;
        powerHalfHeigth = colliderPower.size.y / 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // save screen edges in world coordinates
        float screenZ = -cam.transform.position.z;

        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(Screen.width, Screen.height, screenZ);

        Vector3 lowerLeftCornerWorld = cam.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld = cam.ScreenToWorldPoint(upperRightCornerScreen);

        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;

        ClampInScreen();
    }

    void ClampInScreen()
    {
        Vector3 positionScore = MenuScore.transform.position;
        Vector3 positionPower = PowerUp.transform.position;

        float screenLeftTrue = screenLeft; //- 165f;

        //Debug.Log(positionScore.x + " " + screenRight + " " + scoreHalfWidth*4);
        //Debug.Log(positionPower.x + " " + screenLeftTrue + " " + scoreHalfWidth);

        if (positionScore.x + scoreHalfWidth*4 > screenRight )
        {
            positionScore.x -= scoreHalfWidth;
            MenuScore.transform.position = positionScore;
        }
        else if (screenRight - positionScore.x  > scoreHalfWidth * 8)
        {
            positionScore.x += scoreHalfWidth;
            MenuScore.transform.position = positionScore;
        }
        if (positionPower.x - scoreHalfWidth*4 < screenLeft)
        {
            positionPower.x += scoreHalfWidth;
            PowerUp.transform.position = positionPower;
        }
        else if (positionPower.x - screenLeft > scoreHalfWidth * 8)
        {
            positionPower.x -= scoreHalfWidth;
            PowerUp.transform.position = positionPower;
        }
    }
}
