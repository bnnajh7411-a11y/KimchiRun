using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 9f;
    public float fallMultiplier = 2.5f;
    public float upMultiplier = 2.0f;
    public float apexMultiplier = 3.0f;
    public float apexThreshold = 2.0f;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private int jumpsRemaining;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. 점프 입력 처리
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpsRemaining--; // 1씩 줄이기 (압축!)
        }

        // 2. 점프 물리가 적용되는 세 가지 상태 처리 (최고점, 상승, 하강)
        if (Mathf.Abs(rb.linearVelocity.y) < apexThreshold)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (apexMultiplier - 1) * Time.deltaTime; // += 로 압축!
        }
        else if (rb.linearVelocity.y > 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (upMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 3. 바닥(위쪽 면)을 밟았을 때 점프 횟수 초기화
        if (collision.contacts[0].normal.y > 0.5f)
        {
            jumpsRemaining = maxJumps;

        }
    }
}
