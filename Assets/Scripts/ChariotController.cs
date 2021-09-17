using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChariotController : MonoBehaviour
{
    public Animator anime;

    public Rigidbody2D chariot;
    public Rigidbody2D wheel;

    public float initialImpulse;
    public float chariotTorque;
    public float speed;

    private float movement;

    // Start is called before the first frame update
    void Start()
    {
        // Play the background song
        FindObjectOfType<AudioManager>().Play("PlayTheme0");
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        /*if (Input.GetButtonDown("Horizontal"))
        {
            movement *= initialImpulse;
        }*/
    }

    private void FixedUpdate()
    {
        // Stop or Start the horse walk animation if the player is or is not pressing "Horizontal"
        if (anime.GetBool("isWalking"))
        {
            if (movement == 0)
            {
                anime.SetBool("isWalking", false);
            }
        }
        else if (!anime.GetBool("isWalking"))
        {
            if (movement != 0)
            {
                anime.SetBool("isWalking", true);
            }
        }

        chariot.AddTorque((-1) * movement * chariotTorque * Time.fixedDeltaTime);
        wheel.AddTorque((-1) * movement * speed * Time.fixedDeltaTime);

        if (chariot.position.y < -15)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
