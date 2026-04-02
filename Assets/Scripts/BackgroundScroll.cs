using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;
    private MeshRenderer meshRenderer;
    private float offset;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        offset += Time.deltaTime * scrollSpeed;

        meshRenderer.material.SetTextureOffset("_BaseMap", new Vector2(offset, 0));
    }
}