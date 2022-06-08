using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Melee Weapon", fileName = "New Melee Weapon")]
public class WeaponMeleeScriptable : WeaponScriptable
{
    [SerializeField] private int attackRange;
}
