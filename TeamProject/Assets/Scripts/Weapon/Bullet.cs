using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    public GameObject bloodHitEffect;

    private void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.TryGetComponent<PlayerActions>(out PlayerActions player)) { return; }
        if (other.gameObject.TryGetComponent<EnemyStats>(out EnemyStats enemy))
        {
            Debug.Log("Enemy Was Shooted");
            //GameObject effect = GameObject.Instantiate(bloodHitEffect, transform.position, Quaternion.identity);
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    public void SetBulletDamage(int damage)
    {
        this.damage = damage;
    }
}
