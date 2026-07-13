using TMPro;
using UnityEngine;

namespace DesignPatterns.Decorator
{
    public class WeaponUIView : MonoBehaviour
    {
        [SerializeField] private TMP_Text weaponNameText;
        [SerializeField] private TMP_Text damageText;
        [SerializeField] private TMP_Text helpText;

        public void Initialize()
        {
            if (helpText != null)
            {
                helpText.text = "1. : Add Fire\n" +
                                "2. : Add Poision\n" +
                                "3. : Add Critical\n" +
                                "Space : Attack\n" +
                                "R : Reset";
            }
        }
        public void Refresh(string weaponName, int damage)
        {
            if (weaponNameText != null) weaponNameText.text = "Weapon : " + weaponName;
            if (damageText != null) damageText.text = "Damage : " + damage;
        }
    }
}
