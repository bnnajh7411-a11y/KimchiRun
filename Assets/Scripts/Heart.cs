using UnityEngine;

public class Heart : MonoBehaviour
{
    public Sprite HeartOn;
    public Sprite HeartOff;
    public int LiveNumber;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        if (GameManager.Instance.Lives >= LiveNumber)
        {
            spriteRenderer.sprite = HeartOn;
        }
        else
        {
            spriteRenderer.sprite = HeartOff;
        }
    }

}
