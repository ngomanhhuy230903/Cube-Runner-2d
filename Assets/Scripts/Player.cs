using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    Rigidbody2D m_rb;
    bool m_isGrounded;
    GameController m_gc;
    public AudioSource aus;
    public AudioClip jumpSound;
    public AudioClip loseSound;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        if (isJumpKeyPressed && m_isGrounded)
        {
            m_rb.AddForce(Vector2.up * jumpForce);
            m_isGrounded = false;
            if(aus && jumpSound)
            {
                aus.PlayOneShot(jumpSound);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            m_isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("IncrementPoint"))
        {
            Debug.Log("+1 Point");
            m_gc.incrementScore();
        }
        if (col.gameObject.CompareTag("Obstacle"))
        {
            if (aus && loseSound)
            {
                aus.PlayOneShot(loseSound);
            }
            m_gc.gameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
