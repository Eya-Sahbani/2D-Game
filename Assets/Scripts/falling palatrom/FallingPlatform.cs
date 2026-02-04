using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 1f;
    private float resetDelay = 3f;

    [SerializeField] private Rigidbody2D rb;

    private Vector3 startPos;
    private bool triggered = false;

    private void Start()
    {
        startPos = transform.position;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !triggered)
        {
            triggered = true;
            StartCoroutine(FallAndReset());
        }
    }

    private IEnumerator FallAndReset()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;   // fall

        yield return new WaitForSeconds(resetDelay);
        ResetPlatform();
    }

    private void ResetPlatform()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = startPos;
        triggered = false;
    }
}
