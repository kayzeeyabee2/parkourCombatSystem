using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public float sprintSpeed = 4f;
    public float jump = 8f;
    //private int tiltSpeed = 2;
    private Vector3 tilt;
    private Vector3 tiltDirection;
    private CharacterController controller;
    private Vector3 Velocity;
    private float grav = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * speed);

        //simulates gravity
        Velocity.y += grav * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);

        //Apply sprint and forward tilt
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * Time.deltaTime * sprintSpeed);
            Quaternion tilt = Quaternion.Euler (10, 0, 0);
            tiltDirection = transform.forward;
            transform.eulerAngles = tilt * tiltDirection;
        }
        else
        {
            //resets rotation
            tilt = new Vector3 (0, 0, 0);
            transform.eulerAngles = tilt;
        }

        //Makes object face the direction of movement
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        //Simple jump
        if (Input.GetButtonDown("Jump"))
        {
            Velocity.y += Mathf.Sqrt(jump * -2f * grav);
        }
    }
}
