using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerView playerView;
    public PlayerService playerService {  get; private set; }

    private void Start()
    {
        playerService = new PlayerService(playerView);
    }

}
