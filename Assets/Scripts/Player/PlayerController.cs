using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController
{
    PlayerView playerView;
    PlayerModel playerModel;

    public PlayerController(PlayerModel playerModel, PlayerView playerView)
    {
        this.playerModel = playerModel;
        this.playerView = playerView;

        playerView.SetController(this);
    }

    public Vector3 Move(Vector2 direction)
    {
        Vector3 move  = (playerView.transform.right * direction.x + playerView.transform.forward * direction.y) * playerModel.moveSpeed  *Time.deltaTime;
        return move;

    }
}
