using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase
{
    protected WeaponScriptable weapon;
    
    protected WeaponBase()
    {
        this.weapon = null;
    }
    protected WeaponBase(WeaponScriptable weapon)
    {
        this.weapon = weapon;
    }
    public static WeaponBase SetNewWeapon(WeaponScriptable weapon)
    {
        if (weapon.GetType() == typeof(WeaponMeleeScriptable)) { return new WeaponMelee(weapon); }
        if (weapon.GetType() == typeof(WeaponDistanceScriptable)) { return new WeaponDistance(weapon); }
        return null;
    }
    public WeaponScriptable GetWeapon()
    {
        return weapon;
    }
    public abstract void Attack();
}
