using UnityEngine;

public class KeyAxis : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float health;
    private bool isGrounded;
    private bool isRunning;

    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        isRunning = Mathf.Abs(move) > 0.01f && isGrounded;
        animator.SetBool("Run", isRunning);

        if (move != 0)
        {
            transform.localScale = new Vector3(move > 0 ? 1f : -1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            animator.SetBool("Jump", true);
            rb.velocity = new Vector2(0, jumpForce);
            isGrounded = false;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameManager.Instance.TriggerGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        animator.SetBool("Jump", false);

        if (collision.gameObject.tag == "Obstacle")
        {
            GameManager.Instance.TriggerGameOver();
        }
    }
}