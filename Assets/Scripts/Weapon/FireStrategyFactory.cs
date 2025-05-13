using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valorant.Weapon
{
    public class FireStrategyFactory
    {
        public static IFireStrategy GetStrategy(FireType fireType)
        {
            switch (fireType)
            {
                case FireType.Assault:
                    return new AssaultShot();
                default:
                    return null;
            }
        }
    }

}
