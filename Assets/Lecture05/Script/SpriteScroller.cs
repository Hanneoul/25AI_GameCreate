using UnityEngine;

/// <summary>
/// SpriteRenderer의 텍스처 UV 오프셋을 시간에 따라 증가시켜
/// 이미지가 '왼쪽에서 오른쪽'으로 흐르는 것처럼 보이게 한다.
/// - 별도 셰이더 필요 없음 (기본 스프라이트 셰이더 사용)
/// - MaterialPropertyBlock으로 머티리얼 복제 없이 안전하게 적용
/// 사용법:
///   1) 스크롤할 스프라이트 텍스처 Wrap Mode = Repeat
///   2) 이 스크립트를 SpriteRenderer가 붙은 오브젝트에 추가
///   3) speed 값만 조절 (기본 0.3)
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteScroller : MonoBehaviour
{
    [Tooltip("초당 얼마나 이동할지 (UV 타일 단위). 값이 클수록 빨리 흐름.")]
    public float speed = 0.3f; // +면 좌→우, -면 우→좌

    [Tooltip("스크롤을 멈추고 싶으면 끄기")]
    public bool scrolling = true;

    // 내부 상태
    private SpriteRenderer sr;
    private MaterialPropertyBlock mpb;
    private float offsetX; // 누적 오프셋 (0~1로 래핑)
    private static readonly int MainTexST = Shader.PropertyToID("_MainTex_ST");

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        mpb = new MaterialPropertyBlock();
        offsetX = 0f;
        ApplyOffset();
    }

    void Update()
    {
        if (!scrolling || sr == null) return;

        // 시간에 따라 오프셋 증가 → 오른쪽으로 흐르는 듯이 보임
        offsetX += speed * Time.deltaTime;

        // 값이 너무 커지지 않게 0~1로 래핑
        if (offsetX > 1f) offsetX -= 1f;
        else if (offsetX < 0f) offsetX += 1f;

        ApplyOffset();
    }

    private void ApplyOffset()
    {
        // _MainTex_ST = (tilingX, tilingY, offsetX, offsetY)
        sr.GetPropertyBlock(mpb);
        mpb.SetVector(MainTexST, new Vector4(1f, 1f, offsetX, 0f));
        sr.SetPropertyBlock(mpb);
    }
}