using UnityEngine;
using Valorant.Weapon;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;

    private IInputCommand fireCommand;
    private IInputCommand reloadCommand;


    public void Start()
    {
        if (currentWeapon == null)
        {
            Debug.LogError("No weapon assigned to WeaponHandler.");
            return;
        }
        EquipWeapon(currentWeapon);
    }


    public void EquipWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        fireCommand = new FireCommand(currentWeapon);
        reloadCommand = new ReloadCommand(currentWeapon);
    }

    public IInputCommand GetFireCommand() => fireCommand;
    public IInputCommand GetReloadCommand() => reloadCommand;
    public Weapon GetCurrentWeapon() => currentWeapon;
}
