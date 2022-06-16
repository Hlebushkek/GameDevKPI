using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private WeaponBase weapon;
    [SerializeField] private List<PickupWeapon> avaliableToPickUpWeapons = new List<PickupWeapon>();

    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Transform meleeAttackPoint;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && avaliableToPickUpWeapons.Count != 0)
        {
            DropWeapon();
            weapon = WeaponBase.SetNewWeapon(avaliableToPickUpWeapons[0].GetWeapon());
            weapon.SetOwner(this);
            avaliableToPickUpWeapons[0].WeaponWasPickedUp();
        }
        if (Input.GetMouseButtonDown(0) && weapon != null)
        {
            weapon.Attack();
        }
    }

    public void AddToPickupList(PickupWeapon weapon)
    {
        avaliableToPickUpWeapons.Add(weapon);
    }
    public void RemoveFromPickupList(PickupWeapon weapon)
    {
        avaliableToPickUpWeapons.Remove(weapon);
    }

    public void DropWeapon()
    {
        if (weapon != null)
        {
            GameObject dropedWeapon = Resources.Load<GameObject>("WeaponToPickUp");
            GameObject dropedWeaponGameObj = GameObject.Instantiate<GameObject>(dropedWeapon, this.transform.position, Quaternion.identity);
            PickupWeapon pickup = dropedWeaponGameObj.GetComponent<PickupWeapon>();
            pickup.SetWeapon(weapon.GetWeapon());
        }
    }

    public Transform GetShootingPoint()
    {
        return shootingPoint;
    }
}
