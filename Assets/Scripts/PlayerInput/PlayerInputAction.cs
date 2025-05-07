using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputAction 
{
    private PlayerInput input;
    public InputAction moveAction;
    public InputAction cameraAction;



    public void init(PlayerInput playerInput )
    {
        input = playerInput;
        moveAction = input.actions["Move"];
        cameraAction = input.actions["Look"];
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
