using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{
    PlayerController playerController;
    private PlayerInput input;
    private InputAction moveAction;
    public CharacterController characterController;

    private Vector2 readValue;
    
    public PlayerView()
    {
        
    }

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        moveAction = input.actions["Move"];
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void SetController(PlayerController playerController)
    {
        this.playerController = playerController;
    }


    private void Update()
    {
        GetReadValue();
        playerController.Movement(GetReadValue());
    }


    public Vector2 GetReadValue()
    {
        readValue = moveAction.ReadValue<Vector2>();
        return readValue;
    }

    



}
