using TMPro;                      // TextMeshPro를 사용하기 위한 네임스페이스 (UI 텍스트 표시용)
using UnityEngine;                // Unity의 기본 클래스 (MonoBehaviour, GameObject 등)
using UnityEngine.InputSystem;    // 새 입력 시스템(Input System) 사용을 위한 네임스페이스

/*
Player 오브젝트에는 반드시 Rigidbody2D + Collider2D가 붙어 있어야 충돌이 감지된다.

Floor와 Enemy 오브젝트에도 Collider2D가 있어야 하고, 각각 **Tag를 “Floor”, “Enemy”**로 지정해야 한다.

UI 텍스트는 Canvas 아래에 TextMeshPro 오브젝트를 만들고, 이 스크립트의 text 변수에 연결해야 한다.

점프 높이를 바꾸려면 Inspector 창에서 JumpPower 값을 조정하면 된다.
*/
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;               // Rigidbody2D: 물리엔진(중력, 충돌 등)을 적용할 때 사용
    bool isJumping = true;        // 점프 중인지 여부를 저장하는 변수
    public float JumpPower = 10.0f; // 점프 힘의 크기 (Inspector에서 조절 가능)

    public GameObject text;       // “Game Over” 같은 UI 텍스트 오브젝트를 연결하기 위한 변수

    // Start() : 게임이 시작될 때 한 번만 실행되는 함수
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Player 오브젝트에 붙은 Rigidbody2D 컴포넌트를 가져옴
        isJumping = true;                  // 처음엔 공중에 있다고 가정 (점프 중)
        Debug.Log("Player : isJumping = true");
        text.SetActive(false);             // 시작할 때 텍스트(UI)를 숨김 (ex. "Game Over" 안 보이게)
    }

    // OnCollisionEnter2D() : Player가 다른 2D Collider와 부딪혔을 때 자동으로 호출됨
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트의 태그(Tag)가 "Floor"이면 (바닥이라면)
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Player : Floor 충돌");
            isJumping = false;             // 바닥에 닿았으므로 점프할 수 있는 상태로 변경
            Debug.Log("Player : isJumping = false");
        }

        // 충돌한 오브젝트의 태그(Tag)가 "Enemy"이면 (적과 닿았을 때)
        if (collision.gameObject.CompareTag("Enemy"))
        {
            text.SetActive(true);          // 텍스트(UI)를 켜서 게임오버 표시 등으로 사용
        }
    }

    // Update() : 매 프레임마다 한 번씩 호출됨 (게임의 실시간 로직)
    void Update()
    {
        // SpaceBar가 눌렸고, 현재 점프 중이 아닐 때만 점프 가능
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isJumping)
        {
            Debug.Log("Player : 점프(Space Bar Pressed)");
            rb.linearVelocity = new Vector2(0.0f, JumpPower); // 위쪽 방향(Y축)으로 점프
            isJumping = true;                                // 다시 공중 상태로 변경
            Debug.Log("Player : isJumping = true");
        }
    }
}


