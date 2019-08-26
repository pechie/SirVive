using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 4f;
    public float jumpSpeed = 6f;
    private float movement = 0f;
    private Rigidbody2D rigidbody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    public Vector3 respawnPoint;
    public int livesLeft = 5;
    public GameManager gameManager;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        respawnPoint = rigidbody.transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        isTouchingGround = Physics2D.OverlapPoint(groundCheckPoint.position, groundLayer);
        if (movement < 0f)
        {
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
            transform.localScale = new Vector2(-0.5f, 0.5f);
        }
        else if (movement > 0f)
        {
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            if (livesLeft > 0)
            {
                livesLeft -= 1;
            }
            if (livesLeft == 0)
            {
                gameManager.EndGame();
            }
            gameManager.Respawn();
        }
        if (other.tag == "Finish")
        {
            Debug.Log("Finish");
        }
    }
}
