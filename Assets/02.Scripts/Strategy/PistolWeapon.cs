using UnityEngine;

namespace DesignPatterns.Strategy
{
    [CreateAssetMenu(fileName = "PistolWeapon", menuName = "Weapons/Pistol")]
    public class PistolWeapon : WeaponStrategy
    {
        [Header("Bullet Prefab")]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float bulletSpeed = 15.0f;

        public override void Fire(GameObject owner, Transform firePoint)
        {
            base.Fire(owner, firePoint);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = firePoint.forward * bulletSpeed;
            }
        }
    }
}
