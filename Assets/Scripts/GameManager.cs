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
    public int MyScore;

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
            MyScore = 0;
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

    public float CalculateGameSpeed()
    {
        if (State != GameState.Playing)
        {
            return 5f;
        }
        float speed = 5f + CalculateScore() * 0.05f;
        return Mathf.Min(speed, 30f);
    }

    private void SaveScore()
    {
        MyScore = CalculateScore();
        int HighScore = GetHighScore();
        if (MyScore > HighScore)
        {
            PlayerPrefs.SetInt("HighScore", MyScore);
            PlayerPrefs.Save();
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    public int CalculateScore()
    {
        int score = MyScore + Mathf.FloorToInt(Time.time - playStartTime);
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
