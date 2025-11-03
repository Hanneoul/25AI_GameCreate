using UnityEngine;

//  PlayerController: Player 오브젝트의 움직임을 제어하는 스크립트
public class L2PlayerController : MonoBehaviour
{
      // 플레이어의 현재 X좌표를 기억할 변수
    float start_point = 0.0f;

      // Start(): 게임 시작 시 한 번만 실행되는 함수
    void Start()
    {
            // start_point를 1 증가시킴 (초기 위치를 약간 오른쪽으로)
        start_point++;

            // transform.position : 현재 오브젝트의 위치를 나타내는 속성
            // Vector3(x, y, z) : 3D 공간의 좌표값
            // → 즉, 시작할 때 플레이어의 위치를 (1, 0, 0)에 둔다.
        transform.position = new Vector3(start_point, 0.0f, 0.0f);
    }

      // Update(): 매 프레임마다 반복 실행되는 함수 (매초 60번 이상 호출됨)
    void Update()
    {
        // X좌표를 조금씩 줄여서 플레이어를 왼쪽(-X방향)으로 이동시킴
        start_point = start_point - 0.005f;

        // y, z 좌표는 현재 상태 그대로 유지 → x만 이동
        transform.position = new Vector3(start_point, transform.position.y, transform.position.z);
    }
}