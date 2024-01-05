using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HedgehogScript : MonoBehaviour
{
    public float moveSpeed;
    public float moveDistance;

    private Vector3 initialPosition;
    private bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 movement = moveRight ? Vector3.right : Vector3.left;
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, initialPosition) >= moveDistance)
        {
            moveRight = !moveRight;
        }
    }

    void Attack()
    {

    }
}
