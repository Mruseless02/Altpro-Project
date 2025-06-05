using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Players players;
    private float Force;
    private bool isGrounded = false;
    private Rigidbody2D rb;
    private float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Force = players.force;
        jumpForce = players.jumpforce;
    }

    // Update is called once per frame
    void Update()
    {
        MovementControl();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void MovementControl()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Force, rb.velocity.y);
        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
