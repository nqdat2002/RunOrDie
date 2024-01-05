using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;       
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        JohnMovement john = other.GetComponent<JohnMovement>();
        GruntScript grunt = other.GetComponent<GruntScript>();
        if (grunt != null)
        {
            grunt.Hit(1);
        }
        if (john != null)
        {
            john.Hit(1);
        }
        DestroyBullet();
    }
}
