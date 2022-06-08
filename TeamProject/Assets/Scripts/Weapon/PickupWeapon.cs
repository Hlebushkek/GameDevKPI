using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PickupWeapon : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private WeaponData weapon;

    private PlayerActions player;
    private void Start()
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        SetWeapon(weapon);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        other.TryGetComponent<PlayerActions>(out player);
        
        if (player)
        {
            player.AddToPickupList(weapon);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (player)
        {
            player.RemoveFromPickupList(weapon);
            player = null;
        }
    }

    public void SetWeapon(WeaponData weapon)
    {
        this.weapon = weapon;
        spriteRenderer.sprite = weapon.GetSprite();
    }
    public void WeaponWasPickedUp()
    {
        Destroy(this.gameObject);
    }
}
