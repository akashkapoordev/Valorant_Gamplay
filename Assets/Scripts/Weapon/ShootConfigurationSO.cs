using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootConfiguration", menuName = "GunMechanics/ShootConfiguration", order = 2)]
public class ShootConfigurationSo : ScriptableObject
{
    public LayerMask hitMask;
    public Vector3 spread =  new Vector3(0.1f, 0.1f, 0.1f);
    public float fireRate = 0.25f;
}
