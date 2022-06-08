using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScriptable : ScriptableObject
{
    [SerializeField] private Sprite sprite;

    [SerializeField] private string weaponName;
    [SerializeField] private int damage;
    [SerializeField] private float attackSpeed;
    
    public Sprite GetSprite() { return sprite; }
    public string GetName() { return weaponName; }
    public int GetWeaponDamage() { return damage; }
    public float GetWeaponAttackSpeed() { return attackSpeed; }
}
