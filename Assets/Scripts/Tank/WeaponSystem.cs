using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float projectileForce = 20f;

    public void Fire()
    {
        if (projectilePrefab == null || firePoint == null) return;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
              rb.linearVelocity = firePoint.forward * projectileForce;
        }

        Destroy(projectile, 3f);
    }
}