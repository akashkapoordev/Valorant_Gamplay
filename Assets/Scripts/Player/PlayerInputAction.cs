using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputAction 
{
    private PlayerInput input;
    public InputAction moveAction;
    public InputAction cameraAction;
    public InputAction jumpAction;
    public InputAction leftSprintAction;


    public void init(PlayerInput playerInput )
    {
        input = playerInput;
        moveAction = input.actions["Move"];
        cameraAction = input.actions["Look"];
        jumpAction = input.actions["Jump"];
        leftSprintAction = input.actions["Sprint"];


        jumpAction.performed += ctx => GameService.Instance.eventService.OnJumpPressed.InvokeEvent();
        leftSprintAction.performed += ctx => GameService.Instance.eventService.OnLeftShiftPressed.InvokeEvent();
        leftSprintAction.canceled += ctx => GameService.Instance.eventService.OnLeftShiftReleased.InvokeEvent();


    }

    public Vector2 updateMoveValue()
    {
        return moveAction.ReadValue<Vector2>();
    }

    public Vector2 updateCameraValue()
    {
        return cameraAction.ReadValue<Vector2>();
    }



   
}
