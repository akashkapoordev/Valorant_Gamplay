using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valorant.Weapon
{
    public class AssaultShot : IFireStrategy
    {
        public void Fire(Transform firePoint, Transform muzzleTransfrom, WeaponDataSO weaponDataSO)
        {
            Debug.DrawRay(firePoint.position, firePoint.forward * 100f, Color.red, 0.1f);
            if (Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit hit, weaponDataSO.maxDistance))
            {
                Vector3 targetPoint = hit.point;
                Vector3 directionWithoutSpread = targetPoint - firePoint.position;

                float x = Random.Range(-1, 1);
                float y = Random.Range(-1, 1);

                Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

                GameObject currentBullet = GameObject.Instantiate(weaponDataSO.bulletPrefab, firePoint.position, Quaternion.LookRotation(directionWithSpread.normalized));
                currentBullet.transform.Rotate(90, 0, 0);

                currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * 10, ForceMode.Impulse);
             
                if (weaponDataSO.muzzleFlashPrefab != null)
                {
                    GameObject flash = GameObject.Instantiate(weaponDataSO.muzzleFlashPrefab, muzzleTransfrom.position, muzzleTransfrom.rotation);
                    flash.transform.SetParent(muzzleTransfrom);
                    GameObject.Destroy(flash, 1f);
                }
            }
        }
    }
}

