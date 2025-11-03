using TMPro;                   // 💬 TextMeshPro 관련 기능 (UI 텍스트 표시용)
using UnityEngine;
using UnityEngine.InputSystem;  // 🎮 새로운 입력 시스템 (Input System Package) 사용을 위해 필요

// 🧍‍♂️ L4_1PlayerController : 점프, 애니메이션, 충돌 등을 제어하는 플레이어 컨트롤 스크립트
public class L4_1PlayerController : MonoBehaviour
{
    // 🧱 Rigidbody2D : 2D 물리효과(중력, 점프 등)를 담당
    Rigidbody2D rb;

    // 🌙 isJumping : 현재 점프 중인지 아닌지를 판단하는 플래그
    bool isJumping = true;

    // 🔧 점프 힘(세기) — Inspector에서 조절 가능
    public float JumpPower = 10.0f;

    // 🪧 게임 오버 텍스트나 알림 텍스트 같은 UI 오브젝트 연결용
    public GameObject text;

    // 🎭 Animator : 애니메이션 재생을 제어
    Animator animator;

    // ✅ Start() : 게임이 시작될 때 한 번만 실행
    void Start()
    {
        // Animator와 Rigidbody2D를 컴포넌트에서 찾아서 변수에 저장
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // 처음에는 공중(점프 상태)이라고 가정
        isJumping = true;
        Debug.Log("Player : isJumping = true");

        // 시작할 때 텍스트 UI는 숨겨둠 (ex. “Game Over” 텍스트)
        text.SetActive(false);
    }

    // 🧱 OnCollisionEnter2D() : 다른 Collider2D와 충돌했을 때 자동으로 호출됨
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 🪨 바닥(Floor)과 충돌했을 때
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Player : Floor 충돌");
            // 바닥에 닿았으므로 이제 점프 가능 상태로 전환
            isJumping = false;
            Debug.Log("Player : isJumping = false");
        }

        // 👾 적(Enemy)과 충돌했을 때
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // 텍스트(예: “GAME OVER”)를 화면에 표시
            text.SetActive(true);
        }
    }

    // 🔁 Update() : 매 프레임마다 호출 (초당 수십 번 실행)
    void Update()
    {
        // 🖱️ 스페이스바가 이번 프레임에서 눌렸는지 감지하고,
        // 동시에 점프 중이 아닐 때만 점프를 허용한다.
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isJumping)
        {
            Debug.Log("Player : 점프(Space Bar Pressed)");

            // 🎬 애니메이션 재생 : "PlayerJump" 애니메이션을 처음부터 재생
            // (-1, 0f)는 어떤 레이어든 즉시 처음부터 재생한다는 의미
            animator.Play("PlayerJump", -1, 0f);

            // ⬆️ Rigidbody2D의 속도를 직접 지정 (Y축 방향으로 점프)
            // linearVelocity는 기존 속도를 무시하고 새로운 속도로 덮어쓴다.
            rb.linearVelocity = new Vector2(0.0f, JumpPower);

            // 점프 상태로 전환 (바닥에 닿기 전까지는 다시 점프 불가)
            isJumping = true;
            Debug.Log("Player : isJumping = true");
        }
    }
}
