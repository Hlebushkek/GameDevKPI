using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Distance Weapon", fileName = "New Distance Weapon")]
public class WeaponDistanceScriptable : WeaponScriptable
{
    [SerializeField] private int bulletsInShot;
    [SerializeField] private int bulletsMaxCapacity;
    [SerializeField] private int bulletsMaxInClip;
    private int bulletsCurrentCapacity;
    private int bulletsCurrentInClip;
    public int GetBulletsInShot()
    {
        return bulletsInShot;
    }
    public void Reload()
    {
        int bulletsNeeded = bulletsMaxInClip - bulletsCurrentInClip;
        
        if (bulletsMaxCapacity > bulletsNeeded)
        {
            bulletsCurrentInClip = bulletsMaxInClip;
            bulletsCurrentCapacity -= bulletsNeeded;
        }
        else
        {
            
        }
    }
}


