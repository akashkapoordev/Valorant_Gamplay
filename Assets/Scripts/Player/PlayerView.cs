using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{
    PlayerController playerController;
    private PlayerInput input;
    private InputAction moveAction;
    private Rigidbody rb;

    public PlayerView()
    {
        
    }

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        moveAction = input.actions["Move"];
    }

    public void SetController(PlayerController playerController)
    {
        this.playerController = playerController;
    }


    public void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();


        rb.AddForce(playerController.Move(moveInput),ForceMode.VelocityChange);
    }


    public void FixedUpdate()
    {
       
    }
}
