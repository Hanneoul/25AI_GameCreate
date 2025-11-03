using UnityEngine;
using UnityEngine.InputSystem;   // 🎮 새 Input System
using UnityEngine.SceneManagement; // 🌐 씬 로드 관련 네임스페이스

// 🎞️ SceneChanger
// Space 키를 누르면 지정된 씬으로 전환한다.
public class SceneChanger : MonoBehaviour
{
    // 🔧 전환할 씬 이름 (인스펙터에서 직접 설정 가능)
    public string nextSceneName = "NextScene";

    void Update()
    {
        // 🔹 Space 키 입력 감지
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("SceneChanger : 스페이스바 입력 감지 → 씬 전환");

            // 🎯 씬 전환 (해당 씬이 Build Settings에 등록되어 있어야 함)
            SceneManager.LoadScene(nextSceneName);
        }
    }
}