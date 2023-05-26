using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public float moveSpeed, jumpForce;

    private Vector2 moveInput;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        myRigidbody.velocity = new Vector3(moveInput.x * moveSpeed, myRigidbody.velocity.y, moveInput.y * moveSpeed);
    }
}
