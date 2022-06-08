using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDistance : WeaponBase
{
    private GameObject bullet;
    
    public WeaponDistance(WeaponScriptable weapon) : base(weapon) {}
    override public void Attack()
    {
        WeaponDistanceScriptable weapon = (WeaponDistanceScriptable)this.weapon;

        int bulletsCount = weapon.GetBulletsInShot();
        
        for (int i = 0; i < bulletsCount; i++)
        {
            Debug.Log("Instantiate bullet");
            //Instantiate(bullet, this.transform.position, Quaternion.identity);
        }
    }
    private void Relod()
    {
        
    }
}
