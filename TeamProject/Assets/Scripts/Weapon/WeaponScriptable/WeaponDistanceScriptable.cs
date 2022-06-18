using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Distance Weapon", fileName = "New Distance Weapon")]
public class WeaponDistanceScriptable : WeaponScriptable
{
    [SerializeField] private int bulletsInShot;
    [SerializeField] private int bulletsMaxCapacity;
    private int bulletsCurrentAmount;

    public override void GameLaunched()
    {
        bulletsCurrentAmount = bulletsMaxCapacity;
    }
    public int GetBulletsInShot()
    {
        return bulletsInShot;
    }
    public int GetBulletsMaxCapacity()
    {
        return bulletsMaxCapacity;
    }
    public int GetBulletsCurrentAmount()
    {
        return bulletsCurrentAmount;
    }

    public void Reload()
    {
        bulletsCurrentAmount -= bulletsInShot;
    }
}


