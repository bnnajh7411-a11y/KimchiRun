using UnityEngine;

public class EnermyController : MonoBehaviour
{
    GameManager gameMgrObject;
    void Start()
    {
        TakeDamage(10);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("damage" + damage);
        return;
    }

    void Update()
    {
        
    }
}
