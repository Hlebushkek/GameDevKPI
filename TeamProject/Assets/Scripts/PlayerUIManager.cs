using UnityEngine;
using UnityEngine.UI;
public class PlayerUIManager : MonoBehaviour
{
    private Animator uiAnimator;
    [SerializeField] private TMPro.TextMeshProUGUI bulletsText;
    [SerializeField] private Image blackPanelImage;

    private void Awake()
    {
        uiAnimator = GetComponent<Animator>();
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

    public void ShowTransitionAnim()
    {
        uiAnimator.SetTrigger("StartTransitionAnim");
    }
}
