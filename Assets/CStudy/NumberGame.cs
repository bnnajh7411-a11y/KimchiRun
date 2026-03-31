using System;
using UnityEngine;

public class NumberGame : MonoBehaviour
{
    int tryCount = 0;
    void Start()
    {
        Debug.Log("=================");
        Debug.Log("숫자 맞히기 게임 시작");
        Debug.Log("1~% 사이의 숫자를 맞혀보세요.");
        Debug.Log("[1] [2] [3] [4] [5] 키를 누르세요.");
        Debug.Log("=================");
    }

    void Update()
    {
        int input = -1;

        if (Input.GetKeyDown(KeyCode.Alpha1)) input = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2)) input = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3)) input = 3;
        if (Input.GetKeyDown(KeyCode.Alpha4)) input = 4;
        if (Input.GetKeyDown(KeyCode.Alpha5)) input = 5;
        if (input != -1)
        {
            CheckAnswer(input);
        }
    }

    private void CheckAnswer(int input)
    {
        tryCount++;
        Debug.Log($"입력: {input}, 시도 횟수: {tryCount}");
    }
}
