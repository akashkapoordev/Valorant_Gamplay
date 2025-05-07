using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

   private void GroundMovement(Vector2 input)
    {
        Vector3 move = new Vector3(input.x, 0, input.y);
        move.y = 0;

        move *= playerModel.moveSpeed;
        playerView.characterController.Move(move * Time.deltaTime);
    }

    public void Movement(Vector2 input)
    {
        GroundMovement(input);
    }

    public PlayerView getPlayerView()
    {
        return playerView;
    }

  
}
