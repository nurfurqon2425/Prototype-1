using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField]
    private TextMeshProUGUI speedometerText;
    [SerializeField]
    private TextMeshProUGUI engineTorqueText;
    [SerializeField]
    private List<WheelCollider> allWheels;
    //[SerializeField]
    //private GameObject centerOfMass;

    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float rpm = 10.0f;
    [SerializeField]
    private float horsePower = 0.0f;
    private const float turnSpeed = 25.0f;
    private float horizontalInput;
    private float verticalInput;
    private const float kphConverter = 3.6f;
    private const float mphConverete = 2.237f;
    private int wheelsOnGround;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move the vehicle

        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");

        horizontalInput = 0;
        verticalInput = 0;

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1;
        }else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }

        //transform.Translate(0, 0, 1); //Direction with coordinate

        if (IsOnGround())
        {
            // Direction with Vector3
            // Move according vertical input
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput); 
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);

            //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput); // Move strafe side

            // Rotate according horizontal input
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * kphConverter * verticalInput);
            speedometerText.SetText("Speed: " + speed + " kph");

            rpm = Mathf.Round((speed % 30) * 25);
            engineTorqueText.SetText("Torque: " + rpm + "rpm");
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
