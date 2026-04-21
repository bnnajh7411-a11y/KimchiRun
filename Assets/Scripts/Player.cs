using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("점프 설정 (Jump Settings)")]
    public float jumpForce = 9f;
    public float fallMultiplier = 2.5f;
    public float upMultiplier = 2.0f;
    public float apexMultiplier = 3.0f;
    public float apexThreshold = 2.0f;
    public int maxJumps = 2;

    public bool isInvincible = false;


    private Rigidbody2D rb;
    private int jumpsRemaining;
    private Animator animator;
    private Collider2D collider2D;
    private SpriteRenderer spriteRenderer;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        HandleJumpInput();
        HandleJumpPhysics();
    }



    private void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpsRemaining--;

            if (animator != null)
            {
                animator.SetInteger("state", 1);
            }
        }
    }

    private void HandleJumpPhysics()
    {
        float velocityY = rb.linearVelocity.y;
        float gravityY = Physics2D.gravity.y;

        // 최고점에 도달했을 때 (Apex)
        if (Mathf.Abs(velocityY) < apexThreshold)
        {
            rb.linearVelocity += Vector2.up * gravityY * (apexMultiplier - 1) * Time.deltaTime;
        }
        // 상승 중일 때 (Rising)
        else if (velocityY > 0)
        {
            rb.linearVelocity += Vector2.up * gravityY * (upMultiplier - 1) * Time.deltaTime;
        }
        // 하강 중일 때 (Falling)
        else if (velocityY < 0)
        {
            rb.linearVelocity += Vector2.up * gravityY * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            jumpsRemaining = maxJumps;

            if (animator != null)
            {
                animator.SetInteger("state", 2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            Destroy(other.gameObject);

            if (!isInvincible)
            {
                Damage();
                CameraShake.Instance.Shake(0.2f, 0.1f);
            }
        }
        else if (other.gameObject.CompareTag("Food"))
        {

            Destroy(other.gameObject);
            Heal();
        }
        else if (other.gameObject.CompareTag("Golden"))
        {

            Destroy(other.gameObject);
            StartInvincible();
        }

    }

    private void Heal()
    {
        GameManager.Instance.AddLive();
    }
    private void Damage()
    {
        GameManager.Instance.RemoveLive();
        if (GameManager.Instance.Lives <= 0)
        {
            Debug.Log("GameOver");
            KillPlayer();
        }
    }

    private void StartInvincible()
    {
        isInvincible = true;
        spriteRenderer.color = new Color(1f, 1f, 0, 1f);
        Invoke("StopInvincible", 5f);
    }
    private void StopInvincible()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1f);
        isInvincible = false;
    }

    private void KillPlayer()
    {
        collider2D.enabled = false;
        spriteRenderer.color = new Color(1f, 0.5f, 0.5f, 1f);
        animator.enabled = false;
        rb.AddForceY(jumpForce, ForceMode2D.Impulse);

    }
}