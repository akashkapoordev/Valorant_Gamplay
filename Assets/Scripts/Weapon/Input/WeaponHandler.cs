using UnityEngine;
using Valorant.Weapon;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;

    private IInputCommand fireCommand;


    public void Start()
    {
        if (currentWeapon == null)
        {
            Debug.LogError("No weapon assigned to WeaponHandler.");
            return;
        }
        EquipWeapon(currentWeapon);
    }

    //public start WeaponHandler(Weapon startingWeapon)
    //{
    //    EquipWeapon(startingWeapon);
    //}

    public void EquipWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        fireCommand = new FireCommand(currentWeapon);
    }

    public IInputCommand GetFireCommand() => fireCommand;
    public Weapon GetCurrentWeapon() => currentWeapon;
}
