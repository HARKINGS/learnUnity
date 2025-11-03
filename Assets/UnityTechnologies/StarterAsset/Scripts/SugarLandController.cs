using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class SugarLandController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    private const float MAX_SPEED = 11.0f;
    [SerializeField]
    private InputAction moveAction;
    private Rigidbody2D rb2D;
    private Vector2 move;

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
        // Vector2 position = rigidbody2D.position + move * speed * Time.deltaTime;
        // rigidbody2D.MovePosition(position);
    }

    void FixedUpdate()
    {
        Vector2 position = rb2D.position + move * speed * Time.deltaTime;
        rb2D.MovePosition(position);

        if (move.x != 0 || move.y != 0)
        {
            speed += 0.2f;
            speed = speed > MAX_SPEED ? MAX_SPEED : speed;
        }
        else
        {
            speed -= 0.5f;
            speed = speed < 5.0f ? 5.0f : speed;
        }
    }
}
