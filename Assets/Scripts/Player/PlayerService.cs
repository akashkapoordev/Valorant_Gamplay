using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerModel playerModel;

   public  PlayerService(PlayerView playerView )
    {
        playerModel = new PlayerModel();
        playerController = new PlayerController(playerModel,playerView);
    }

    public PlayerView getPlayerView()
    {
        return playerController.getPlayerView();
    }


}
