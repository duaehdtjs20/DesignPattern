using UnityEngine;

namespace DesignPatterns.Decorator
{
    public class DecoratorTest : MonoBehaviour
    {
        [SerializeField] private WeaponVisualView weaponVisualView;
        [SerializeField] private WeaponUIView weaponUIView;

        private IWeapon weapon;

        private bool hasFire;
        private bool hasPoison;
        private bool hasCritical;
        void Start()
        {
            if(weaponUIView != null)
            {
                weaponUIView.Initialize();
            }
            ResetWeapon();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) AddFire();
            if (Input.GetKeyDown(KeyCode.Alpha2)) AddPoison();
            if (Input.GetKeyDown(KeyCode.Alpha3)) AddCritical();

            if (Input.GetKeyDown(KeyCode.Space)) Attack();
            if (Input.GetKeyDown(KeyCode.R)) ResetWeapon();
        }
        private void AddFire()
        {
            if (hasFire) return;

            // 현재 무기를 크리티컬 데코레이터로 감싼다.
            weapon = new FireWeaponDecorator(weapon);
            hasFire = true;
            if(weaponVisualView != null)
            {
                weaponVisualView.SetFire(true);
            }
            RefreshView();
        }
        private void AddPoison()
        {
            if (hasPoison) return;

            // 현재 무기를 크리티컬 데코레이터로 감싼다.
            weapon = new PoisonWeaponDecorator(weapon);
            hasPoison = true;
            if(weaponVisualView != null)
            {
                weaponVisualView.SetPoison(true);
            }
            RefreshView();
        }
        private void AddCritical()
        {
            if (hasCritical) return;

            // 현재 무기를 크리티컬 데코레이터로 감싼다.
            weapon = new CriticalWeaponDecorator(weapon);
            hasCritical = true;
            if(weaponVisualView != null)
            {
                weaponVisualView.SetCritical(true);
            }
            RefreshView();
        }
        private void Attack()
        {
            Debug.Log(weapon.GetName() + "Attack Damage : " + weapon.GetDamage());
        }
        // 무기를 기본상태로 초기화
        private void ResetWeapon()
        {
            weapon = new BasicSword();
            hasFire = false;
            hasPoison = false;
            hasCritical = false;

            if(weaponVisualView != null)
            {
                weaponVisualView.ResetEffects();
            }
        }
        private void RefreshView()
        {
            if(weaponUIView != null)
            {
                weaponUIView.Refresh(weapon.GetName(), weapon.GetDamage());
            }
        }
    }
}
