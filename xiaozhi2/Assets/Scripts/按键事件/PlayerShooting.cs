using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 3f;  // �ӵ�����3����Զ�����

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // 1. �����ӵ�
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // 2. ���ӵ�һ�����ٶ�
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * bulletSpeed;

            // 3. 3����Զ������ӵ�
            Destroy(bullet, bulletLifetime);
        }
    }
}