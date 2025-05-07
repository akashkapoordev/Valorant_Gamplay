using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public float moveSpeed = 5f;
    private Vector2 readValue;

    public void setReadValue(Vector2 readValue)
    {
        this.readValue = readValue;
    }

    public Vector2 getReadValue()
    {
        return readValue;
    }
}
