// BossController.cs

using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 5f;
    public float shootingInterval = 2f;

    private bool isShooting = false;

    private void Start()
    {
        InvokeRepeating("ShootBullet", shootingInterval, shootingInterval);
    }

    private void ShootBullet()
    {
        // Instantiate bullet at the spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Set bullet speed
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = new Vector2(-bulletSpeed, 0f);

        // Destroy the bullet after a certain time (adjust as needed)
        Destroy(bullet, 3f);
    }

    public bool IsShooting
    {
        get { return isShooting; }
    }
}
