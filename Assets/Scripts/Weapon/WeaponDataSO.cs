using UnityEngine;
using Valorant.Weapon;
[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapons/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    [Header("General Info")]
    public string weaponName;
    public FireType fireType;

    [Header("Ammo")]
    public int maxAmmo = 30;
    public float fireRate = 10f;
    public float reloadTime = 2f;
    public float bulletSpeed = 10f;
    public float bulletSpread = 0.1f;   

    [Header("Damage & Range")]
    public float damage = 10f;
    public float maxDistance = 100f;

    [Header("Effects")]
    public GameObject muzzleFlashPrefab;
    public GameObject impactEffectPrefab;
    public GameObject bulletPrefab;
}
