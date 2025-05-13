using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapons/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    public string weaponName;
    public int maxAmmo;
    public float fireRate;
    public float damage;
    public FireType fireType;

    public GameObject muzzleFlashPrefab;
    public GameObject impactEffectPrefab;
}
