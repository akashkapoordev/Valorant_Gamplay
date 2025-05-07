using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInputAction playerInputAction;
    PlayerController playerController;
    public CharacterController characterController;
    

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    public void SetController(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void SetPlayerInputAction(PlayerInputAction inputAction)
    {
        this.playerInputAction = inputAction;
    }

    public PlayerInputAction GetPlayerInputAction => playerInputAction;
    private void Update()
    {
        playerController.Movement(playerInputAction.updateMoveValue());
    }

    

    



}
