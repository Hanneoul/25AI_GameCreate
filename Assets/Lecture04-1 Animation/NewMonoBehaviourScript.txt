using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class UVScroller : MonoBehaviour
{
    [Tooltip("초당 UV 이동량 (x=가로, y=세로)")]
    public Vector2 speed = new Vector2(0.1f, 0f);

    // 선택: 레이어별 파랄랙스 세팅에 쓰기 편하도록 초기 오프셋
    public Vector2 startOffset = Vector2.zero;

    private SpriteRenderer sr;
    private MaterialPropertyBlock mpb;
    private Vector2 offset;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        mpb = new MaterialPropertyBlock();
        offset = startOffset;
    }

    void Update()
    {
        // 시간에 따라 오프셋 증가
        offset += speed * Time.deltaTime;

        // SpriteRenderer에 적용된 머티리얼의 _MainTex_ST : (scale.x, scale.y, offset.x, offset.y)
        // 스케일은 1,1로 두고 오프셋만 갱신
        sr.GetPropertyBlock(mpb);
        mpb.SetVector("_MainTex_ST", new Vector4(1f, 1f, offset.x, offset.y));
        sr.SetPropertyBlock(mpb);
    }
}


using UnityEngine;

public class PlayAnimationOnSpace : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Animator Controller 안에 등록된 애니메이션 이름으로 실행
            animator.Play("MyAnimationClipName", -1, 0f);
        }



        using UnityEngine;

public class PlayAnimationOnSpace : MonoBehaviour
    {
        private Animator animator;

        void Start()
        {
            // Animator 컴포넌트 가져오기
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            // 스페이스바를 누르면 Trigger 발동
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("PlayAnim");
            }
        }
    }