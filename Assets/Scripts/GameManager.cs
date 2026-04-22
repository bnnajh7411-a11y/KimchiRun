using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Intro,
    Playing,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State = GameState.Intro;

    public int Lives = 3;
    private bool isGameOver = false;

    private float playStartTime;
    public int HighScore = 0;
    public int MyScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (State == GameState.Intro)
        {
            Lives = 3;
            isGameOver = false;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                State = GameState.Playing;
                UIManager.Instance.IntroUI.SetActive(false);
                UIManager.Instance.ItemSpawner.SetActive(true);

                playStartTime = Time.time;
            }
        }

        else if (State == GameState.Playing)
        {
            if (Lives == 0)
            {
                State = GameState.GameOver;
                UIManager.Instance.ItemSpawner.SetActive(false);
                SaveScore();
            }
        }
        else if (State == GameState.GameOver)
        {
            if (isGameOver == false)
            {
                Invoke("GameOverEvent", 3f);
            }
            isGameOver = true;
        }
    }

    private void SaveScore()
    {
        MyScore = CalculateScore();
        if (MyScore > HighScore)
        {
            HighScore = MyScore;
        }
    }

    public int CalculateScore()
    {
        int score = Mathf.FloorToInt(Time.time - playStartTime);
        return score;
    }

    private void GameOverEvent()
    {
        State = GameState.Intro;
        SceneManager.LoadScene("Main");
    }

    public void AddLive()
    {
        Lives = Mathf.Min(Lives + 1, 3);
    }

    public void RemoveLive()
    {
        Lives--;

    }

}
