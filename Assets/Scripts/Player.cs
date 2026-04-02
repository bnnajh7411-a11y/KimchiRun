using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 12f;

    public float fallMultiplier = 2.5f;

    public float upMultiplier = 2.0f;

    public int maxJumps = 2;


    private Rigidbody2D rb;
    private int jumpsRemaining;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 남은 점프 횟수가 있으면 공중에서도 점프
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpsRemaining--;
        }

        // 올라갈 때 빠른 감속
        if (rb.linearVelocity.y > 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (upMultiplier - 1) * Time.deltaTime;
        }
        // 떨어질 때 가속
        else if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥(위쪽을 향하는 면)에 충돌 시 점프 횟수 초기화
        if (collision.contacts[0].normal.y > 0.5f)
        {
            jumpsRemaining = maxJumps;
        }
    }
}
