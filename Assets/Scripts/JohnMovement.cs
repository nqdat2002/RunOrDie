using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Speed;
    public float JumpForce;
    public HealthBarScript playerhealth;
    public int maxHealth;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    private int _currentHealth;
    private bool _isDie = false;

    public bool IsDie {  get { return _isDie; } }
    public void Hit(int damage = 1)
    {
        _currentHealth -= damage;
        playerhealth.SetHealth(_currentHealth);
        Debug.Log("Damage to John");
        if (_currentHealth == 0)
        {
            _isDie = true;
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        _currentHealth = maxHealth;
        playerhealth.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);
        //Debug.DrawRay(transform.position, Vector3.down * 0.1f, color: Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.12f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);

        //Debug.Log($"Shoot Direction: {direction}");
        //Debug.Log($"Shoot Position: {transform.position + direction * 0.1f}");
    }

    private void Die()
    {
        if (transform.position.y <= -230f)
        {
            _isDie = true;
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }
}
