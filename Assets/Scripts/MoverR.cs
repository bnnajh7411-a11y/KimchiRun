using UnityEngine;

public class MoverR : MonoBehaviour
{

    void Update()
    {
        float moveSpeed = GameManager.Instance.CalculateGameSpeed();
        transform.position -= Vector3.left * moveSpeed * Time.deltaTime;
    }
}
