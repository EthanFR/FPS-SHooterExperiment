using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public CharacterController controller;
    // Start is called before the first frame update
    public float speed = 3f;
    public float gravity = -9.81f;
    public Transform groundcheck;
    public float GroundDistance = .04f;
    public LayerMask groundmask;
    
    Vector3 velocity;
    bool isgrounded;
    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundcheck.position, GroundDistance, groundmask);

        if (isgrounded && velocity.y < 0)
            {
            velocity.y = -2f;
            }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
