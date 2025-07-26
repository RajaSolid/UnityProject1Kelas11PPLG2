using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movespeed = 5f;
    [SerializeField] private float jumpspeed = 5f;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private Transform groundCheck;
    private bool isGrounded;
    private Rigidbody rb;
    private Vector3 move;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        //groundcheck
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundlayer);
        
        //movement input
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        //Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpspeed, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        //Movement speed
        Vector3 targetVelocity = move.normalized * movespeed;
        
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
    }
}
