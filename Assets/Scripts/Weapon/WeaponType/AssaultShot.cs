using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valorant.Weapon
{
    public class AssaultShot : IFireStrategy
    {
        public void Fire(Transform firePoint, WeaponDataSO weaponDataSO)
        {
            Debug.DrawRay(firePoint.position, firePoint.forward * 100f, Color.red, 0.1f);
            if (Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit hit, weaponDataSO.maxDistance))
            {
                Debug.Log("Hit: " + hit.collider.name);

                if (weaponDataSO.muzzleFlashPrefab != null)
                {
                    GameObject flash = GameObject.Instantiate(weaponDataSO.muzzleFlashPrefab, firePoint.position, firePoint.rotation);
                    GameObject.Destroy(flash, 1f);
                }
            }
        }
    }
}

