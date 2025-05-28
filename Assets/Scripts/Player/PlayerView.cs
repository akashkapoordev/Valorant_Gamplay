using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Valorant.Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerInput playerInput;
        private PlayerInputAction playerInputAction;
        private PlayerController playerController;
        public CharacterController characterController;
        [SerializeField] private CameraController cameraController;
        [SerializeField]
        private GunType Gun;
        [SerializeField]
        private Transform GunParent;
        [SerializeField]
        private List<GunScriptableObject> Guns;

        [Space]
        [Header("Runtime Filled")]
        public GunScriptableObject ActiveGun;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            playerInput = GetComponent<PlayerInput>();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GunScriptableObject gun = Guns.Find(gun => gun.type == Gun);

            if (gun == null)
            {
                Debug.LogError($"No GunScriptableObject found for GunType: {gun}");
                return;
            }

            ActiveGun = gun;
            gun.Spwan(GunParent, this);
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

                if (Mouse.current.leftButton.isPressed && this.ActiveGun != null)
                {
                    this.ActiveGun.Shoot();
                }
                Vector2 moveInput = playerInputAction.updateMoveValue();
                playerController.Movement(moveInput);
                cameraController.Turn();
            }
        }
    }

}
