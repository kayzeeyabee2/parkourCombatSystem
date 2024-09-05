using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpKill : MonoBehaviour
{
    bool isGrounded = false;
    public Transform groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Check to see if the player is on the floor or not
        if (groundCheck.transform.position.y  > 0)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If conditions are met, should print text into console
        if (other.gameObject.CompareTag("Enemy") && groundCheck.transform.position.y > other.transform.position.y && isGrounded == false)
        {
            print("You hit their head");
        }
    }
}
