using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject John;
    public GameObject BulletPrefab;
    private float LastShoot;
    private int _currentHealth;
    public int maxHealth;
    public HealthBarScript health;
    public double distanceGrunt = 0.75f;
    public int CurrentHealth { get { return _currentHealth; } }
    public void Hit(int damage = 1)
    {
        _currentHealth -= damage;
        health.SetHealth(_currentHealth);
        if (_currentHealth < 0)
        {
            GameManager.currentScore += 150;
            Destroy(gameObject);
            health.Destroy();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        health.SetMaxHealth(maxHealth);
        _currentHealth = maxHealth;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        health.transform.position = new Vector3(screenPos.x, screenPos.y + 50, screenPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (John == null) return;
        Vector3 direction = John.transform.position - transform.position;

        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        health.transform.position = new Vector3(screenPos.x, screenPos.y + 50, screenPos.z);

        if (distance < distanceGrunt && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        JohnMovement john = FindObjectOfType<JohnMovement>();
        if (john != null && !john.IsDie)
        {
            Debug.Log("Shooter");
            Vector3 direction = new(transform.localScale.x, 0.0f, 0.0f);
            GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
            bullet.GetComponent<BulletScript>().SetDirection(direction);
        }
    }
}
