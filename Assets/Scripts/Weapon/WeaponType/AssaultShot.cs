using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valorant.Bullet;

namespace Valorant.Weapon
{
    public class AssaultShot : IFireStrategy
    {
        private BulletService bulletService;

        public AssaultShot(BulletService bulletService)
        {
            this.bulletService = bulletService;
        }
        public void Fire(Transform firePoint, Transform muzzleTransfrom, WeaponDataSO weaponDataSO)
        {
            if (Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit hit, weaponDataSO.maxDistance))
            {
                bulletService.SpwanBullet(weaponDataSO, firePoint, muzzleTransfrom, hit.point, weaponDataSO.bulletSpeed);
                bulletService.SpawnImpact(hit.point, hit.normal, weaponDataSO.impactEffectPrefab);
            }
        }
    }
}

