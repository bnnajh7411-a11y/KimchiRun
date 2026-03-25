using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private int hp = 100;
    private int score = 0;

    //public string playerName = "용사";
    //public int hp = 100;
    //public float moveSpeed = 5.0f;
    //private bool isAlive = true;


    //int playerHp = 100;

    void Start()
    {

        Debug.Log("시작 체력: " + hp);
        Debug.Log("시작 점수: " + score);

        hp = hp - 30;
        Debug.Log("30 데미지 후 체력: " + hp);

        score = score + 100;
        Debug.Log("100점 획득 후 점수: " + score);
    



        //Debug.Log("==플레이어 정보==");
        //Debug.Log("이름: "+playerName);
        //Debug.Log("체력: "+hp);
        //Debug.Log("이동 속도: "+moveSpeed);
        //Debug.Log("생존 여부: "+isAlive);

        //Debug.Log("게임 시작");
        //Debug.Log("플레이어의 체력: " + playerHp);
        //Debug.Log($"플레이어의 체력은 {playerHp}입니다.");

        //playerHp = 200;
        //Debug.LogWarning("주의! 입력된 hp가 너무 큼.");

        //Debug.LogError("진짜 심각"+playerHp);

    }

    void Update()
    {

    
    }
}
