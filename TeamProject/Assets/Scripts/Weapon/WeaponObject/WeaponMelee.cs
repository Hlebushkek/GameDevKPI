using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : WeaponBase
{
    public WeaponMelee(WeaponScriptable weapon) : base(weapon) {}
    override public void Attack()
    {
        Debug.Log("Melee attack");
    }
}
