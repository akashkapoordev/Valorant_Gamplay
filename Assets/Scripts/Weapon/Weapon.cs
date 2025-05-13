using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valorant.Weapon
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] WeaponDataSO dataSO;
        public Transform firePoint;

        private IFireStrategy fireStrategy;

        private int currentAmmo;
        private float lastFireTime;
        private bool isReloading;
        private float reloadStartTime;

        private void Awake()
        {
            fireStrategy = FireStrategyFactory.GetStrategy(dataSO.fireType);
            currentAmmo = dataSO.maxAmmo;
        }

        private void Update()
        {
            if (isReloading && Time.time - reloadStartTime >= dataSO.reloadTime)
            {
                FinishReload();
            }
        }
      


        public void Fire()
        {
            if (!CanShoot()) return;
            fireStrategy.Fire(firePoint, dataSO);
            currentAmmo--;
            lastFireTime = Time.time;
        }

        public bool CanShoot()
        {
            if (isReloading) return false;
            if (currentAmmo <= 0) return false;
            if (Time.time - lastFireTime < 1f / dataSO.fireRate) return false;

            return true;
        }

        public void StartReload()
        {
            if (isReloading || currentAmmo == dataSO.maxAmmo) return;
            isReloading = true;
            reloadStartTime = Time.time;
        }

        private void FinishReload()
        {
            isReloading = false;
            currentAmmo = dataSO.maxAmmo;
        }

        public int GetCurrentAmmo()
        {
            return currentAmmo;
        }

        public int GetMaxAmmo()
        {
            return dataSO.maxAmmo;
        }

        public bool ISReloading()
        {
            return isReloading;
        }
    }

}
