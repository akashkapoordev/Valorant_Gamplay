using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valorant.Weapon;

public class ReloadCommand : IInputCommand
{
    private Weapon weapon;

    public ReloadCommand(Weapon weapon)
    {
        this.weapon = weapon;
    }
    public void Execute()
    {
        weapon.StartReload();
    }
}
