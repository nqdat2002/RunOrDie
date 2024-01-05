using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float rotationSpeed = 5.0f;
    public float fireRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

 

    private void Shoot()
    {
        Vector3 direction = new(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet = Instantiate(bulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
}
