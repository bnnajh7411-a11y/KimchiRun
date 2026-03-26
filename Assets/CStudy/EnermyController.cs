using UnityEngine;
using UnityEngine.InputSystem;

public class EnermyController : MonoBehaviour
{
    string enemyName = "슬라임";
    int hp = 50;

    void Start()
    {
    }

    void Update()
    {
        var key = Keyboard.current;

        if (key.eKey.wasPressedThisFrame)
        {
            TakeDamage(15);
        }
    }

    void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Debug.Log("슬라임이 쓰러졌다!");
        }
        else
        {
            Debug.Log("현재 체력: "+hp);
        }
    }
}
