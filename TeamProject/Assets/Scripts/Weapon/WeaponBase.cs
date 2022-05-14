using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    protected string weaponName;
    protected int ammoCapacity;
    public abstract void PerformAttack();
    protected abstract void Reload();
}
