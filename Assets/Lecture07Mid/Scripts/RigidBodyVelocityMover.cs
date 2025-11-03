using UnityEngine;
using UnityEngine.InputSystem;

// Rigidbody에 힘(Force)을 가해서 이동
// ✅ 질량, 마찰, 가속도 모두 반영됨 (가속형 이동)
// ⚙️ 중력 ON 상태에서도 작동
[RequireComponent(typeof(Rigidbody2D))]
public class RigidbodyForceMover : MonoBehaviour
{
    public float forceAmount = 10.0f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float x = 0f;
        float y = 0f;

        if (Keyboard.current.wKey.isPressed) y += 1f;
        if (Keyboard.current.sKey.isPressed) y -= 1f;
        if (Keyboard.current.aKey.isPressed) x -= 1f;
        if (Keyboard.current.dKey.isPressed) x += 1f;

        Vector2 moveDir = new Vector2(x, y).normalized;

        // 🚀 AddForce() : 힘을 가해 물리적으로 밀어냄
        rb.AddForce(moveDir * forceAmount, ForceMode2D.Force);

        // 🔸 ForceMode2D 옵션:
        // - Force : 지속적인 힘 (가속도형)
        // - Impulse : 순간적인 힘 (점프, 총알 발사 등에 사용)
    }
}
