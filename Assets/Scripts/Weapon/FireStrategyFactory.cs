using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStrategyFactory 
{
    public static IFireStrategy GetStrategy(FireType fireType)
    {
        switch (fireType)
        {
            case FireType.SingleShot:
                return new SingleShot();
            default:
                return null;
        }
    }
}
