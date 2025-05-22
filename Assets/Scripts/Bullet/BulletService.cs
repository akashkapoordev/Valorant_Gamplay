using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valorant.Bullet
{
    public class BulletService
    {
        public void SpwanBullet(WeaponDataSO weaponDataSO,Transform firePoint,Transform muzzleTransform,Vector3 targetPoint,float spread)
        {
            Vector3 direction = GetDirection(firePoint, targetPoint, 0.1f);

            GameObject currentBullet = GameObject.Instantiate(weaponDataSO.bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
            currentBullet.transform.Rotate(90, 0, 0);

            if(currentBullet.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.AddForce(direction * weaponDataSO.bulletSpeed, ForceMode.Impulse);
            }

            Object.Destroy(currentBullet, 5f);


        if (weaponDataSO.muzzleFlashPrefab != null)
            {
                GameObject flash = GameObject.Instantiate(weaponDataSO.muzzleFlashPrefab, muzzleTransform.position, muzzleTransform.rotation);
                flash.transform.SetParent(muzzleTransform);
                Object.Destroy(flash, 1f);
            }
        }


        public void SpawnImpact(Vector3 hitPoint, Vector3 hitNormal, GameObject impactPrefab)
        {
            if (impactPrefab != null)
            {
                var impact = Object.Instantiate(impactPrefab, hitPoint, Quaternion.LookRotation(hitNormal));
                Object.Destroy(impact, 2f);
            }
        }

        private Vector3 GetDirection(Transform origin,Vector3 target,float spread)
        {
            Vector3 baseDir = (target - origin.position).normalized;
            Vector3 randomDir = new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0f);
            return (baseDir + randomDir).normalized;
        }
    }

}
