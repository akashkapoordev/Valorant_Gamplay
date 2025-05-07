using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventService
{
    private static EventService insatance;
    public static EventService Instance
    {
        get
        {
            if(insatance == null)
            {
                insatance = new EventService();
            }
            return insatance;
        }
    }

    public EventController OnJumpPressed { get;private set; }
    public EventController OnLeftShiftPressed { get;private set; }
    public EventController OnLeftShiftReleased { get; private set; }




    public EventService()
    {
        OnJumpPressed = new EventController();
        OnLeftShiftPressed = new EventController();
        OnLeftShiftReleased = new EventController();
    }
}
