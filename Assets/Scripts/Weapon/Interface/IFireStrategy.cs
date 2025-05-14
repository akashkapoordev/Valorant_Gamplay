using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valorant.Weapon
{
    public interface IFireStrategy
    {
        void Fire(Transform firePoint,Transform muzzleTransform, WeaponDataSO weaponDataSO);
    }

}
