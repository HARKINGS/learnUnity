using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    public float speed = 3f;
    Vector2 move;

    public int maxHealth = 5;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        // QualitySettings.vSyncCount = 0; // Disable VSync
        // Application.targetFrameRate = 10; // Set target frame rate to 10 FPS
    }


    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
        Debug.Log(move);
    }

    void FixedUpdate()
    {
        // Physics updates can be handled here if needed
        Vector2 position = (Vector2)transform.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    void ChangeHealth(int amount)
    {
        // Mathf.Clamp để giới hạn hp min = 0, max = maxHealth
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
