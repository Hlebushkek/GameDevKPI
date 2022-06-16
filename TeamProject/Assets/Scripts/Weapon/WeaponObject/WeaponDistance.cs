using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDistance : WeaponBase
{
    private const float BULLET_FORCE = 40f;
    private GameObject bulletPref;
    
    public WeaponDistance(WeaponScriptable weapon) : base(weapon)
    {
        bulletPref = Resources.Load<GameObject>("Bullet");
    }
    override public void Attack()
    {
        WeaponDistanceScriptable weapon = (WeaponDistanceScriptable)this.weapon;

        int bulletsCount = weapon.GetBulletsInShot();
        
        for (int i = 0; i < bulletsCount; i++)
        {
            Transform shootingPoint = owner.GetShootingPoint();
            GameObject bullet = GameObject.Instantiate(bulletPref, shootingPoint.position, shootingPoint.rotation);
            bullet.transform.eulerAngles += new Vector3(0, 0, 90);
            bullet.GetComponent<Bullet>().SetBulletDamage(weapon.GetWeaponDamage());
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootingPoint.right * BULLET_FORCE, ForceMode2D.Impulse);
        }
    }
    private void Relod()
    {
        ((WeaponDistanceScriptable)weapon).Reload();
    }
}
