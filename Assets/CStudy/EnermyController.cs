using UnityEngine;

public class EnermyController : MonoBehaviour
{

    string enermyName = "고블린";
    int enermyHp = 80;
    float moveSpeed = 2.5f;
    bool isAttack = true;
    void Start()
    {

        Debug.Log("적 이름: "+enermyName);
        Debug.Log("적 체력: "+enermyHp);
        Debug.Log("이동 속도: "+moveSpeed);
        Debug.Log("공격 여부: "+isAttack);
        
    }

    void Update()
    {
        
    }
}
