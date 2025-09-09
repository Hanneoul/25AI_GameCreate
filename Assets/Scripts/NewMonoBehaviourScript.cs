using UnityEngine;

// 2D 캐릭터를 좌우로 움직이고, 스페이스 키로 점프할 수 있게 만드는 스크립트
// ▶ 게임오브젝트에 Rigidbody2D + Collider2D가 반드시 필요합니다.
public class PlayerController2D : MonoBehaviour
{
    // Inspector(인스펙터)에서 직접 조절할 수 있는 변수
    public float moveSpeed = 5f;   // 좌우 이동 속도
    public float jumpForce = 7f;   // 점프 힘

    // 실제 물리 연산을 담당하는 Rigidbody2D 컴포넌트
    private Rigidbody2D rb;

    // 플레이어가 땅에 닿아있는지 확인하는 변수
    // (점프 중복 방지용)
    private bool isGrounded = true;

    // 게임 시작 시 한 번 실행됨
    void Start()
    {
        // 플레이어 오브젝트에 붙어 있는 Rigidbody2D 가져오기
        rb = GetComponent<Rigidbody2D>();
    }

    // 매 프레임마다 실행됨
    void Update()
    {
        // ---- 1. 좌우 이동 처리 ----
        // GetAxisRaw("Horizontal"):
        //   - 왼쪽 화살표 또는 A 키 → -1
        //   - 입력 없음 → 0
        //   - 오른쪽 화살표 또는 D 키 → +1
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Rigidbody2D의 velocity(속도) 값을 직접 바꿔서 이동시킴
        // X축 속도는 입력값 * 이동속도
        // Y축 속도는 기존 값 유지 (점프/중력에 영향 안 주기 위해)
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // ---- 2. 점프 처리 ----
        // 스페이스 키를 눌렀고, 현재 땅에 있을 때만 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Rigidbody2D에 위쪽 방향으로 힘을 가함 (순간적인 힘: Impulse 모드)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // 공중에 떠 있으므로 isGrounded = false 로 설정
            isGrounded = false;
        }
    }

    // 충돌이 시작될 때 자동으로 실행되는 함수
    // (Collider2D + Rigidbody2D 가 있어야 작동)
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 닿은 오브젝트의 태그가 "Ground"일 경우
        // 다시 점프할 수 있도록 isGrounded를 true로 변경
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}