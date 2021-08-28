using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChariotController : MonoBehaviour
{
    public Rigidbody2D chariot;
    public Rigidbody2D wheel;

    public float chariotTorque;
    public float speed;

    private float movement;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        chariot.AddTorque((-1) * chariotTorque * Time.fixedDeltaTime);
        wheel.AddTorque((-1) * movement * speed * Time.fixedDeltaTime);
    }
}
