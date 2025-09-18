using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 3f;  // 子弹存在3秒后自动销毁

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // 1. 生成子弹
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // 2. 给子弹一个初速度
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * bulletSpeed;

            // 3. 3秒后自动销毁子弹
            Destroy(bullet, bulletLifetime);
        }
    }
}