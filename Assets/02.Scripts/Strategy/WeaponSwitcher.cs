using UnityEngine;

namespace DesignPatterns.Strategy
{
    public class WeaponSwitcher : MonoBehaviour
    {
        [SerializeField] private PlayerWeaponController weaponController;

        [SerializeField] private WeaponStrategy pistol;
        [SerializeField] private WeaponStrategy shotgun;
        [SerializeField] private WeaponStrategy rocket;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                weaponController.CurrentWeapon = pistol;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                weaponController.CurrentWeapon = shotgun;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                weaponController.CurrentWeapon = rocket;
            }
        }
    }
}
