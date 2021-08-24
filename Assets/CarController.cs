using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody2D car;
    public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public UnityEngine.UI.Image imageFuel;

    public float fuel = 1;
    public float fuelConsumption = 0.1f;

    public float carTorque = 30;
    public float speed = 20;

    private float movement;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        imageFuel.fillAmount = fuel;
    }

    private void FixedUpdate()
    {
        if (fuel > 0)
        {
            // (-1) inverts the moviment side to normal
            backTire.AddTorque((-1) * movement * speed * Time.fixedDeltaTime);
            frontTire.AddTorque((-1) * movement * speed * Time.fixedDeltaTime);
            car.AddTorque((-1) * movement * carTorque * Time.fixedDeltaTime);
        }

        fuel -= fuelConsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;
    }
}
