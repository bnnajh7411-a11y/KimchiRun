using UnityEngine;

public class ImageScale : MonoBehaviour
{
    public float speed = 5f;
    public float amount = 0.2f;

    private Vector3 baseScale;

    private void Awake()
    {
        baseScale = transform.localScale;
    }

    private void OnEnable()
    {
        if (baseScale != Vector3.zero)
        {
            transform.localScale = baseScale;
        }
    }

    private void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * amount;

        transform.localScale = baseScale + new Vector3(offset, offset, 0f);
    }
}
