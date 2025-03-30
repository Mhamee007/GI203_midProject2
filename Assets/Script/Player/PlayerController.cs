using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded;
    private bool isAir;
    
    private float respawnDelay = 2f;
    [SerializeField]float speed = 3f;
    [SerializeField] float jumpForce = 25f;
    [SerializeField] private float friction = 0.9f;
    private Vector3 movement;

    float gravity = Physics.gravity.magnitude;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Player movement----------------------------------------------------

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        movement = new Vector3(moveX, 0, moveZ) * speed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);


        if (Input.GetKey(KeyCode.Space) && isGrounded == true && isAir == false) //Jumping
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (moveX == 0 && moveZ == 0)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x * friction, rb.linearVelocity.y, rb.linearVelocity.z * friction);
        }

    }


    // On ground and Air cheeck---------------------------------------------
    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        isAir = false;

        if (collision.gameObject.CompareTag("wall")) //This player will not run on the wall.
        {
            float moveY = 0f;
            float moveX = 0f;
        }

        if (collision.gameObject.CompareTag("deathZone")) //death player
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        isAir = true;
    }
    
}
