using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // 어디서든 접근할 수 있도록 인스턴스 저장 (싱글톤 패턴)
    public static CameraShake Instance { get; private set; }

    private Vector3 originalPos;

    void Awake()
    {
        // 싱글톤 초기화
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 화면을 흔드는 메인 메서드
    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            // 무작위 위치 계산
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        // 흔들림이 끝나면 원래 위치로 복구
        transform.localPosition = originalPos;
    }
}
