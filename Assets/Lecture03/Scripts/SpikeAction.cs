using UnityEngine;

public class SpikeAction : MonoBehaviour
{
    float speed = 5;  // 가시가 이동할 속도 (초당 5단위)

    // Start() : 게임이 시작될 때 한 번만 호출됨
    void Start()
    {
        // 프레임레이트를 30fps로 제한 (일정한 속도 유지용)
        Application.targetFrameRate = 30;
    }

    // Update() : 매 프레임마다 실행됨 (움직임 처리)
    void Update()
    {
        // Time.deltaTime : 한 프레임이 걸린 시간 (초 단위)
        // => 초당 speed만큼 이동하려면 deltaTime * speed를 해야 함
        float moveVectorX = Time.deltaTime * speed;

        // 현재 위치에서 X축 방향으로 왼쪽(-)으로 이동
        transform.position = new Vector3(
            transform.position.x - moveVectorX,
            transform.position.y,
            transform.position.z
        );
    }

    // OnCollisionEnter2D() : 2D 충돌이 발생할 때 자동 실행
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트의 Tag가 "SpikeDestroyer"라면
        if (collision.gameObject.CompareTag("SpikeDestroyer"))
        {
            // 현재 이 Spike 오브젝트를 파괴
            Destroy(gameObject);
            Debug.Log("Spike : 소멸");  // 콘솔에 로그 표시
        }
    }
}
