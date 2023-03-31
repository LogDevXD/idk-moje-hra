using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 1f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (CanSeePlayer() && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    bool CanSeePlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, target.position - transform.position, out hit))
        {
            if (hit.transform == target)
            {
                return true;
            }
        }
        return false;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = (target.position - transform.position).normalized * bulletSpeed;
    }
}
