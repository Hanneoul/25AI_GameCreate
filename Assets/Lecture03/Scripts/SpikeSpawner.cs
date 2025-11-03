using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    // Inspector에서 연결할 Spike 프리팹
    public GameObject SpikePrefab;

    bool a = true;  // 단 한 번만 생성하기 위한 제어 변수

    // Start() : 게임 시작 시 1회 호출
    void Start()
    {
        // 지금은 비워둠 (필요시 초기화 코드 추가 가능)
    }

    // Update() : 매 프레임마다 실행됨
    void Update()
    {
        // a가 true일 때만 Spike 생성
        if (a)
        {
            Debug.Log("Spawner : Spike 생성");

            // Spike 프리팹을 복제(Instantiate)해서 새 오브젝트를 생성
            GameObject spike = Instantiate(SpikePrefab);

            // 새로 생성된 Spike의 위치를 Spawner와 동일하게 설정
            spike.transform.position = transform.position;

            // 한 번만 실행되도록 플래그를 false로 변경
            a = false;
        }
    }
}
