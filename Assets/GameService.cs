using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    public PlayerView playerView;

    private void Start()
    {
        var playerModel = new PlayerModel();
        var playerController = new PlayerController(playerModel, playerView);
    }
}
