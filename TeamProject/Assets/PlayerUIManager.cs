using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI bulletsText;

    private void Awake()
    {
        bulletsText.enabled = false;
    }

    public void UpdateUI(WeaponScriptable weapon)
    {
        if (weapon.GetType() == typeof(WeaponMeleeScriptable))
        {

        }
        else if (weapon.GetType() == typeof(WeaponDistanceScriptable))
        {
            bulletsText.enabled = true;
            bulletsText.text = "Bullets: " + ((WeaponDistanceScriptable)weapon).GetBulletsCurrentAmount() +
            "/" + ((WeaponDistanceScriptable)weapon).GetBulletsMaxCapacity();
        } else
        {
            bulletsText.enabled = false;
        }
    }
}
