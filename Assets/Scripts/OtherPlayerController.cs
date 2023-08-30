using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float verticalInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move the vehicle

        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");

        horizontalInput = 0;
        verticalInput = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1;
        }

        //transform.Translate(0, 0, 1); //Direction with coordinate

        // Direction with Vector3
        // Move according vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput); // Move strafe side

        // Rotate according horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
