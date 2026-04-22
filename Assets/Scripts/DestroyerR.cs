using UnityEngine;

public class DestroyerR : MonoBehaviour
{
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        float cameraRightEdge = mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect;
        float objectLeftEdge = spriteRenderer.bounds.min.x;

        if (objectLeftEdge > cameraRightEdge)
        {
            Destroy(gameObject);
        }

    }
}
