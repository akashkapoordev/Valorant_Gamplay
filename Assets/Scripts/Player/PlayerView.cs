using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Valorant.Weapon;
namespace Valorant.Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerInput playerInput;
        private PlayerInputAction playerInputAction;
        private PlayerController playerController;
        public CharacterController characterController;
        [SerializeField] private CameraController cameraController;
       public WeaponHandler weaponHandler;


        private void Awake()
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

        public PlayerInput GetInputComponent() => playerInput;
        public PlayerInputAction GetPlayerInputAction() => playerInputAction;

        private void Update()
        {
            if (playerController != null && playerInputAction != null)
            {
                if (Mouse.current.leftButton.wasPressedThisFrame)
                    weaponHandler.GetFireCommand().Execute();
                if (Mouse.current.rightButton.wasPressedThisFrame)
                    weaponHandler.GetReloadCommand().Execute();

                Vector2 moveInput = playerInputAction.updateMoveValue();
                playerController.Movement(moveInput);
                cameraController.Turn();
            }
        }






    }

}
