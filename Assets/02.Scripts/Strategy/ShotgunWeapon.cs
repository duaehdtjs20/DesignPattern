using UnityEngine;

namespace DesignPatterns.Strategy
{
    [CreateAssetMenu(fileName = "ShotgunWeapon", menuName = "Weapons/Shotgun")]
    public class ShotgunWeapon : WeaponStrategy
    {
        [Header("Bullet Prefab")]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float bulletSpeed = 12.0f;

        [SerializeField] private int bulletCount = 5;
        [SerializeField] private float spreadAngle = 25.0f;

        public override void Fire(GameObject owner, Transform firePoint)
        {
            base.Fire(owner, firePoint);

            for (int i = 0; i < bulletCount; i++)
            {
                float angle = Random.Range(-spreadAngle, spreadAngle);

                Quaternion rotation = firePoint.rotation * Quaternion.Euler(0.0f, angle, 0.0f);

                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);

                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = firePoint.forward * bulletSpeed;
                }
            }
        }
    }
}
