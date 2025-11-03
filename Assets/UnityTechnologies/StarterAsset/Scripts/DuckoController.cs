using UnityEngine;
using UnityEngine.InputSystem;

public class DuckoController : MonoBehaviour
{
    public InputAction moveAction;
    Rigidbody2D rb2D;
    Vector2 move;
    public float speed = 0.1f;
    float positive_x_limit = 17.5f;
    float negative_x_limit = -17.5f;
    float positive_y_limit = 8.8f;
    float negative_y_limit = -8.8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = moveAction.ReadValue<Vector2>();
        Vector2 position = rb2D.position + move * speed * Time.deltaTime;
        if(CheckCollisionLimit(position))
            rb2D.MovePosition(position);
    }

    bool CheckCollisionLimit(Vector2 position)
    {
        if (position.x >= positive_x_limit || position.y >= positive_y_limit)
            return false;
        if (position.x <= negative_x_limit || position.y <= negative_y_limit)
            return false;
        return true;
    }

    // void FixedUpdate()
    // {
    //     Vector2 position = rigidbody2D.position + move * speed * Time.deltaTime;
    //     if(CheckCollisionLimit(position))
    //         rigidbody2D.MovePosition(position);
    // }
}
