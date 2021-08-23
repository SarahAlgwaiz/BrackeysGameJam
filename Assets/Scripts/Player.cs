using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variabl//
    [SerializeField] private float runSpeed = 12f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundDist = 0.4f;

    public Transform groundCheck;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //References//
    public CharacterController characterController;

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void Run()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDist,groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * runSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

    }

    
}
