using UnityEngine;

public class PlayerController
{
    private PlayerView playerView;
    private PlayerModel playerModel;

    public PlayerController(PlayerModel playerModel, PlayerView playerView)
    {
        this.playerModel = playerModel;
        this.playerView = playerView;

        playerView.SetController(this);

        GameService.Instance.eventService.OnJumpPressed.AddListener(OnButtonJump);
        GameService.Instance.eventService.OnLeftShiftPressed.AddListener(OnLeftKeyPressed);
        GameService.Instance.eventService.OnLeftShiftReleased.AddListener(OnLeftKeyReleased);
    }

    ~PlayerController()
    {
        GameService.Instance.eventService.OnJumpPressed.RemoveListener(OnButtonJump);
        GameService.Instance.eventService.OnLeftShiftPressed.RemoveListener(OnLeftKeyPressed);
        GameService.Instance.eventService.OnLeftShiftReleased.RemoveListener(OnLeftKeyReleased);
    }

    private void GroundMovement(Vector2 input)
    {
        Vector3 move = new Vector3(input.x, 0, input.y);

        float targetSpeed = playerModel.IsSprinting ? playerModel.SprintSpeed : playerModel.BaseSpeed;
        playerModel.MoveSpeed = Mathf.Lerp(playerModel.MoveSpeed, targetSpeed, playerModel.SprintSpeedTransition * Time.deltaTime);

        move *= playerModel.MoveSpeed;
        move.y = CalculateVerticalVelocity();

        playerView.characterController.Move(move * Time.deltaTime);
    }

    private float CalculateVerticalVelocity()
    {
        if (playerView.characterController.isGrounded && playerModel.VerticalVelocity < 0)
        {
            playerModel.VerticalVelocity = -1;
        }
        else
        {
            playerModel.VerticalVelocity -= playerModel.Gravity * Time.deltaTime;
        }

        return playerModel.VerticalVelocity;
    }

    public void Movement(Vector2 input)
    {
        GroundMovement(input);
    }

    public PlayerView getPlayerView()
    {
        return playerView;
    }

    private void OnButtonJump()
    {
        if (playerView.characterController.isGrounded)
        {
            Debug.Log("Jumped");
            playerModel.VerticalVelocity = Mathf.Sqrt(playerModel.JumpHeight * 2f * playerModel.Gravity);
        }
    }

    private void OnLeftKeyPressed()
    {
        playerModel.IsSprinting = true;
    }

    private void OnLeftKeyReleased()
    {
        playerModel.IsSprinting = false;
    }
}
