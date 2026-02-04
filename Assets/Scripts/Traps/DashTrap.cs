using UnityEngine;

public class DashTrap : MonoBehaviour
{
    [SerializeField] private Vector2 dashDirection = Vector2.right;
    [SerializeField] private float dashForce = 20f;
    [SerializeField] private float lockTime = 0.25f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        PlayerMovement movement = collision.GetComponent<PlayerMovement>();

        rb.velocity = Vector2.zero;

        if (movement != null)
            movement.enabled = false;

        rb.AddForce(dashDirection.normalized * dashForce, ForceMode2D.Impulse);

        Invoke(nameof(EnableMovement), lockTime);
    }

    void EnableMovement()
    {
        PlayerMovement pm = FindObjectOfType<PlayerMovement>();
        if (pm != null)
            pm.enabled = true;
    }
}

