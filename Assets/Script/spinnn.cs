using UnityEngine;

public class spinnn : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float spinispeed;
    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(Vector3.up * spinispeed, ForceMode.Impulse);
    }
}
