using UnityEngine;

[CreateAssetMenu(fileName = "RocketWeapon", menuName = "Weapons/Rocket")]
public class RocketWeapon : WeaponStrategy
{
    [Header("Bullet Prefab")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float rocketSpeed = 8.0f;

    public override void Fire(GameObject owner, Transform firePoint)
    {
        base.Fire(owner, firePoint);

        Quaternion spawnRotation = firePoint.rotation * bulletPrefab.transform.rotation;

        GameObject rocket = Instantiate(bulletPrefab, firePoint.position, spawnRotation);

        Rigidbody rb = rocket.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.linearVelocity = firePoint.forward * rocketSpeed;
        }
    }
}
