using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valorant.Bullet;

namespace Valorant.Weapon
{
    public class FireStrategyFactory
    {
        public static IFireStrategy GetStrategy(FireType fireType)
        {
            switch (fireType)
            {
                case FireType.Assault:
                    Debug.Log("Assault Shot Created");
                    return new AssaultShot(GameService.Instance.bulletService);
                default:
                    return null;
            }
        }
    }

}
