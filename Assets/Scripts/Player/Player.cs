using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variabl//
    [SerializeField] private float runSpeed = 12f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundDist = 0.4f;
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] public float health = 100f;
    [SerializeField] public float MAXHEALTH = 100;

[SerializeField] Ui_Inventory ui_Inventory;
    [SerializeField]
    public float attackPowerOffset = 0;
    public Transform playerBody;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float movementMultiplyer = 1;
    Vector3 velocity;
    bool isGrounded;
    
      
   public int numKeys = 0;

    //References//
    //[SerializeField] private Ui_Inventory ui_Inventory;
    CharacterController characterController;
    //private Inventory inventory;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Awake()
    {
        //inventory = new Inventory();
        //ui_Inventory.SetInventory(inventory);
    }

    void Update()
    {   
        RotateMove();
        Run();
          if(Input.GetKeyUp(KeyCode.Space)){
            ui_Inventory.switchBetweenInventory();
        }
    }
    private void RotateMove()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);
    }
    private void Run()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(Vector3.ClampMagnitude(move, 1.0f) * runSpeed * Time.deltaTime * movementMultiplyer);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
