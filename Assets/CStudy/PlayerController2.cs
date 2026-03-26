using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController2 : MonoBehaviour
{
    private int hp = 100;
    private int score = 0;

    void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("데미지: " + damage + " / 남은 체력: " + hp);
    }

    int GetMaxHP()
    {
        return 100;
    }

    void Start()
    {
        //TakeDamage(25);
        //TakeDamage(40);

        int max = GetMaxHP();
        //Debug.Log("최대 체력: " + max);
    }

    void Update()
    {
        var key = Keyboard.current;
        if (key == null) return;

        if (key.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("스페이스바를 눌렀습니다.");
        }

        if (key.wKey.isPressed)
        {
            Debug.Log("W키 누르는 중...");
        }
    }
}
