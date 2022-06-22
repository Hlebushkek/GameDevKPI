using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private Animator playerAnimator;

    [SerializeField] private WeaponBase weapon;
    [SerializeField] private List<PickupWeapon> avaliableToPickUpWeapons = new List<PickupWeapon>();

    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Transform meleeAttackPoint;

    [SerializeField] private PlayerUIManager playerUI;

    private void Awake() {
        playerAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && avaliableToPickUpWeapons.Count != 0)
        {
            DropWeapon();
            weapon = WeaponBase.SetNewWeapon(avaliableToPickUpWeapons[0].GetWeapon());
            weapon.SetOwner(this);
            playerUI.UpdateUI(weapon.GetWeapon());
            avaliableToPickUpWeapons[0].WeaponWasPickedUp();

            if (weapon.GetType() == typeof(WeaponDistance)) playerAnimator.SetBool("HasDistanceWeapon", true);
            if (weapon.GetType() == typeof(WeaponDistance)) playerAnimator.SetBool("HasMeleeWeapon", true);
        }
        if (Input.GetMouseButtonDown(0) && weapon != null)
        {
            weapon.Attack();
            playerUI.UpdateUI(weapon.GetWeapon());
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

            playerAnimator.SetBool("HasDistanceWeapon", false);
            playerAnimator.SetBool("HasMeleeWeapon", false);
        }
    }

    public Transform GetShootingPoint()
    {
        return shootingPoint;
    }
}
