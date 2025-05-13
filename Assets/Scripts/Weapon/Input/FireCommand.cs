using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valorant.Weapon;

public class FireCommand : IInputCommand
{
    private Weapon weapon;

    public FireCommand(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public void Execute()
    {
        weapon.Fire();
    }
}
