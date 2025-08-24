using UnityEngine;

public class HealZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null) controller.ChangeHealth(1);
    }
}
