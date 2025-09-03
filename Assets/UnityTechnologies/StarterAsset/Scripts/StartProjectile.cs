using UnityEngine;
using UnityEngine.InputSystem;

public class StartProjectile : MonoBehaviour
{
    Rigidbody2D rb2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rb2D.AddForce(direction * force);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Projecttile collision with" + collision.gameObject.name);
        Destroy(gameObject);
    }   
}
