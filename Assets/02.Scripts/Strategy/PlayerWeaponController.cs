using UnityEngine;

// 전략패턴의 Context의 역할
// 어떤 무기인지는 직접적으로 판단하지 않는다.
namespace DesignPatterns.Strategy
{
    public class PlayerWeaponController : MonoBehaviour
    {
        [SerializeField] private WeaponStrategy currentWeapon;
        [SerializeField] private Transform firePoint;

        public WeaponStrategy CurrentWeapon
        {
            get => currentWeapon;
            set
            {
                currentWeapon = value;
                Debug.Log("무기 변경 : " + currentWeapon.WeaponName);
            }
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }
        private void Fire()
        {
            if (currentWeapon == null || firePoint == null) return;

            currentWeapon.Fire(gameObject, firePoint);
        }
    }
}
