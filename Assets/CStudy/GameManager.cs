using UnityEngine;
using UnityEngine.InputSystem;

public enum GameState
{
    Playing,
    Paused,
    GameOver,
    Clear
}

public class GameManager : MonoBehaviour
{

    public EnermyController enermyCtrl;
    //private int gameState = 0;
    private GameState currentState = GameState.Playing;

    void Update()
    {
        Keyboard key = Keyboard.current;
        if (key != null && key.pKey.wasPressedThisFrame)
        {
            currentState = GameState.Paused;
        }

        switch (currentState)
        {
            case GameState.Playing:
                Debug.Log("게임 진행 중");
                break;
            case GameState.Paused:
                Debug.Log("일시 정지");
                break;
            case GameState.GameOver:
                Debug.Log("게임 오버!");
                break;
            case GameState.Clear:
                Debug.Log("클리어!");
                break;
            default:
                Debug.Log("알 수 없는 상태!");
                break;
        }
    }
}