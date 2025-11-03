using UnityEngine;

// 🎞️ SceneScroller : 배경 텍스처를 일정 속도로 계속 움직이게 만들어주는 스크립트
// 예) 구름, 땅, 하늘 배경이 계속 흐르는 듯한 효과를 연출할 때 사용
public class SceneScroller : MonoBehaviour
{
    // 🔧 public 변수로 노출 → Unity 인스펙터(Inspector) 창에서 직접 속도 조절 가능
    // 값이 클수록 배경이 빠르게 움직임
    public float ScrollSpeed = 1.0f;

    // 🎨 현재 오브젝트의 머티리얼을 담을 변수
    Material myMaterial;

    // ✅ Start() : 게임 시작 시 한 번만 실행
    void Start()
    {
        // GetComponent<Renderer>() : 이 오브젝트의 Renderer(렌더러, 화면에 그려주는 컴포넌트)를 가져옴
        // .material : 그 렌더러가 사용하는 머티리얼(Material)을 가져옴
        // 👉 즉, 이 오브젝트의 텍스처를 조작하기 위해 머티리얼을 저장함
        myMaterial = GetComponent<Renderer>().material;
    }

    // 🔁 Update() : 매 프레임마다 실행 (초당 약 60회 이상)
    void Update()
    {
        // Time.deltaTime : 지난 프레임과 이번 프레임 사이의 시간 (초 단위)
        // ScrollSpeed * Time.deltaTime → 초당 일정한 스크롤 속도를 유지하도록 보정
        // mainTextureOffset.x : 머티리얼 텍스처의 현재 X 오프셋 (0~1 사이 값, 1을 넘으면 반복)
        float newOffSetX = myMaterial.mainTextureOffset.x + (ScrollSpeed * Time.deltaTime);

        // 📜 디버그 로그 : 현재 오프셋과 새 오프셋 값을 콘솔에 출력
        Debug.Log("x오프셋 : " + myMaterial.mainTextureOffset.x);
        Debug.Log("뉴오프셋 : " + newOffSetX);

        // 2D 벡터(Vector2)로 새로운 오프셋 값 생성 (x만 바꾸고 y는 그대로 0)
        Vector2 newOffset = new Vector2(newOffSetX, 0);

        // 텍스처의 오프셋을 새 값으로 적용 → 텍스처가 좌우로 움직이는 효과 발생
        myMaterial.mainTextureOffset = newOffset;
    }
}
