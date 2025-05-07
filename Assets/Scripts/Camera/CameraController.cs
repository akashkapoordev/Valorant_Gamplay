using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;

    private Vector2 mouseInput;
  
    private float mouseSensitivity = 100f;
    private float xRotation;

    [SerializeField]private PlayerInput input;
    private InputAction cameraAction;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        cameraAction = input.actions["Look"];
    }
    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        Turn();
    }

    public void Turn()
    {
        mouseInput = cameraAction.ReadValue<Vector2>();
        mouseInput.x *= mouseSensitivity * Time.deltaTime;
        mouseInput.y *= mouseSensitivity * Time.deltaTime;

        xRotation -= mouseInput.y;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        virtualCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        GameService.Instance.playerService.getPlayerView().transform.Rotate(Vector3.up * mouseInput.x);

   
    }
}
