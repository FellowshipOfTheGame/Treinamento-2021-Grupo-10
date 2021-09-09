using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChariotController : MonoBehaviour
{
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
        chariot.AddTorque((-1) * movement * chariotTorque * Time.fixedDeltaTime);
        wheel.AddTorque((-1) * movement * speed * Time.fixedDeltaTime);

        if (chariot.position.y < -6)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
