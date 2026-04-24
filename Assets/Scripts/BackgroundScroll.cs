using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private Material material;

    [Header("변경할 이미지")]
    public Texture2D newBackgroundImage;
    private bool isChanged = false;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        float scrollSpeed = GameManager.Instance.CalculateGameSpeed() / 10;
        material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);

        // 점수가 100점 이상이 될 때 이미지를 한 번만 변경
        if (!isChanged && GameManager.Instance.CalculateScore() >= 100)
        {
            if (newBackgroundImage != null)
            {
                material.mainTexture = newBackgroundImage;
            }
            isChanged = true;
        }
    }
}