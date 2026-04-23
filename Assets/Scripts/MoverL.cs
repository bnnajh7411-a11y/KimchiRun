using UnityEngine;

public class MoverL : MonoBehaviour
{

    void Update()
    {
        float moveSpeed = GameManager.Instance.CalculateGameSpeed();
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
