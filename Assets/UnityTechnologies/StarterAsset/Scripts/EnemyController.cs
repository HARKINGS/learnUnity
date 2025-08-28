using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float changeTime = 3.0f;
    private float timer;
    private int direction = 1;

    public bool vertical;
    public float speed;
    Rigidbody2D rigidbody2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = changeTime;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            position.y += direction * speed * Time.deltaTime;
        }
        else
        {
            position.x += direction * speed * Time.deltaTime;
        }

        rigidbody2d.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
