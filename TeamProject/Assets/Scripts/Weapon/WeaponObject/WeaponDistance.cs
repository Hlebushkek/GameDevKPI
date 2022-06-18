using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDistance : WeaponBase
{
    private const float BULLET_FORCE = 40f;
    private const float BULLET_DELTA_ANGEL = 2;
    private GameObject bulletPref;
    
    public WeaponDistance(WeaponScriptable weapon) : base(weapon)
    {
        bulletPref = Resources.Load<GameObject>("Bullet");
    }
    override public void Attack()
    {
        WeaponDistanceScriptable weapon = (WeaponDistanceScriptable)this.weapon;

        int bulletsCount = weapon.GetBulletsInShot();
        int bulletsCurrentAmount = weapon.GetBulletsCurrentAmount();
        if (bulletsCurrentAmount < 1) { return; }
        else if(bulletsCurrentAmount < bulletsCount) { bulletsCount = bulletsCurrentAmount;}

        Transform shootingPoint = owner.GetShootingPoint();
        Vector2 startVector = Utilities.rotateByDegree(shootingPoint.right, -(float)bulletsCount / 2 * BULLET_DELTA_ANGEL);

        for (int i = 0; i < bulletsCount; i++)
        {
            GameObject bullet = GameObject.Instantiate(bulletPref, shootingPoint.position, shootingPoint.rotation);
            bullet.transform.eulerAngles += new Vector3(0, 0, 90);
            
            bullet.GetComponent<Bullet>().SetBulletDamage(weapon.GetWeaponDamage());

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(Utilities.rotateByDegree(startVector, BULLET_DELTA_ANGEL * i) * BULLET_FORCE, ForceMode2D.Impulse);
        }

        weapon.Reload();
    }
    private void Relod()
    {
        //Delay
    }
}
