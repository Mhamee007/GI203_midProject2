using UnityEngine;

public class IceSpeed : MonoBehaviour
{

    [SerializeField] float SpeedBoostForce = 13f;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Make sure your player has the tag "Player"
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z); // Reset Y velocity
                rb.AddForce(Vector3.forward * SpeedBoostForce, ForceMode.Impulse); // Add upward force
            }
        }

    }
}
