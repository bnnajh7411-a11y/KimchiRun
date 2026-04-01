using UnityEngine;
using UnityEngine.InputSystem;

public class RockPaperScissor : MonoBehaviour
{
    int playScore = 0;
    int cpuScore = 0;
    int round = 1;
    const int maxRound = 3;
    bool isOver = false;
    void Start()
    {
        Debug.Log("[1] 가위  [2] 바위  [3] 보");
        Debug.Log($"{round} 라운드");

    }

    void Update()
    {
        if (isOver) return;



        Keyboard key = Keyboard.current;
        if (key.digit1Key.wasPressedThisFrame) Judge(1);
        if (key.digit2Key.wasPressedThisFrame) Judge(2);
        if (key.digit3Key.wasPressedThisFrame) Judge(3);

    }

    string GetChoiceName(int choice)
    {
        return choice switch
        {
            1 => "가위",
            2 => "바위",
            3 => "보",
            _ => ""
        };
    }

    void Judge(int playChoice)
    {
        int cpuChoice = Random.Range(1, 4);
        Debug.Log($"플레이어: {GetChoiceName(playChoice)} / 컴퓨터: {GetChoiceName(cpuChoice)}");

        if (playChoice == cpuChoice) Debug.Log("무승부");
        else if ((playChoice == 1 && cpuChoice == 3) || (playChoice == 2 && cpuChoice == 1) || (playChoice == 3 && cpuChoice == 2))
        {
            Debug.Log("플레이어 승");
            playScore++;
        }
        else
        {
            Debug.Log("컴퓨터 승");
            cpuScore++;
        }

        Debug.Log($"플레이어 점수: {playScore} // 컴퓨터 점수: {cpuScore}");

        if (round >= maxRound)
        {
            ShowFinalResult();
        }
        else
        {
            round++;
            Debug.Log($"{round} 라운드");
        }
    }

    void ShowFinalResult()
    {
        isOver = true;
        if (playScore > cpuScore)
        {
            Debug.Log("최종 승리!");
        }
        else if (playScore < cpuScore)
        {
            Debug.Log("최종 패배!");
        }
        else
        {
            Debug.Log("최종 무승부!");
        }
    }
}
