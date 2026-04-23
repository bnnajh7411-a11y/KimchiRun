using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        float scrollSpeed = GameManager.Instance.CalculateGameSpeed() / 10;
        material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}