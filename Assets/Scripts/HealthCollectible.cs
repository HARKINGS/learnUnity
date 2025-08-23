using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int healthAmount = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.ChangeHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
