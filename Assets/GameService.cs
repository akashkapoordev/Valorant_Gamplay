using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  Valorant.Player;
public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerView playerView;
    public PlayerService playerService {  get; private set; }
    public EventService eventService { get; private set; }

    private void Start()
    {
        eventService = new EventService();
        playerService = new PlayerService(playerView);
    }

}
