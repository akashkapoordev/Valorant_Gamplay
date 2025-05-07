using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerModel playerModel;
    private PlayerInputAction playerInputAction;

    public PlayerService(PlayerView playerView)
    {
        InitializeVariables(playerView);
    }

    public PlayerView getPlayerView()
    {
        return playerController.getPlayerView();
    }

    public PlayerInputAction getPlayerInputAction()
    {
        return playerInputAction;
    }

    private void InitializeVariables(PlayerView playerView)
    {
        playerModel = new PlayerModel();
        playerController = new PlayerController(playerModel, playerView);
        playerInputAction = new PlayerInputAction();
        playerInputAction.init(playerView.GetPlayerInputAction);
        playerView.SetPlayerInputAction(playerView.GetPlayerInputAction);
    }
}
