using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class PickupWeapon : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private WeaponScriptable weapon = null;

    private PlayerActions player;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (weapon != null) SetWeapon(weapon);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        other.TryGetComponent<PlayerActions>(out player);
        
        if (player)
        {
            player.AddToPickupList(this);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (player)
        {
            player.RemoveFromPickupList(this);
            player = null;
        }
    }

    public void SetWeapon(WeaponScriptable weapon)
    {
        this.weapon = weapon;
        weapon.GameLaunched();
        spriteRenderer.sprite = weapon.GetSprite();
    }
    public WeaponScriptable GetWeapon()
    {
        return weapon;
    }
    public void WeaponWasPickedUp()
    {
        Destroy(this.gameObject);
    }
}
