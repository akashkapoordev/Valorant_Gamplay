using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour 
{
    private CinemachineVirtualCamera virtualCamera;

    private Vector2 mouseInput;

    private float mouseSensitivity = 20f;
    private float xRotation;

    private InputAction cameraAction;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }


    public void Turn()
    {
        mouseInput = GameService.Instance.playerService.getPlayerInputAction().updateCameraValue();
        mouseInput.x *= mouseSensitivity * Time.deltaTime;
        mouseInput.y *= mouseSensitivity * Time.deltaTime;

        xRotation -= mouseInput.y;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        virtualCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        GameService.Instance.playerService.getPlayerView().transform.Rotate(Vector3.up * mouseInput.x);
    }
}
