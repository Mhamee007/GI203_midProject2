using UnityEngine;

public class SlimeSlow : MonoBehaviour
{
    [SerializeField] float SlowForce = 3f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Make sure your player has the tag "Player"
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z); // Reset Y velocity
                rb.AddForce(new Vector3(0, 0, -SlowForce), ForceMode.Impulse);
            }
        }

    }
}
