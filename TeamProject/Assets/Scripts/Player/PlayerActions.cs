using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private WeaponData weapon;
    [SerializeField] private List<WeaponData> avaliableToPickUpWeapons = new List<WeaponData>();

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && avaliableToPickUpWeapons.Count != 0)
        {
            weapon = avaliableToPickUpWeapons[0];
            avaliableToPickUpWeapons.RemoveAt(0);
            NewWeaponWasPickedUp();
        }
    }

    /// Weapon Pickups
    private void NewWeaponWasPickedUp()
    {
        Debug.Log("Picked up : ");
        
    }
    public void AddToPickupList(WeaponData weapon)
    {
        avaliableToPickUpWeapons.Add(weapon);
    }
    public void RemoveFromPickupList(WeaponData weapon)
    {
        avaliableToPickUpWeapons.Remove(weapon);
    }
}
