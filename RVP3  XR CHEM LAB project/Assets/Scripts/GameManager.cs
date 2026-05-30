using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentState;

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

    private void Start()
    {
        SetState(GameState.Menu);
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;

        Debug.Log("GAME STATE: " + newState);

        switch (newState)
        {
            case GameState.Menu:
                HandleMenu();
                break;

            case GameState.Tutorial:
                HandleTutorial();
                break;

            case GameState.Playing:
                HandlePlaying();
                break;

            case GameState.Paused:
                HandlePaused();
                break;

            case GameState.Results:
                HandleResults();
                break;
        }
    }

    void HandleMenu()
    {
        Debug.Log("MENU STATE");
    }

    void HandleTutorial()
    {
        Debug.Log("TUTORIAL STATE");
    }

    void HandlePlaying()
    {
        Debug.Log("PLAYING STATE");

        TimerManager.Instance.StartTimer();

        GameEvents.OnGameStarted?.Invoke();
    }

    void HandlePaused()
    {
        Debug.Log("PAUSED STATE");
    }

    void HandleResults()
    {
        Debug.Log("RESULTS STATE");

        GameEvents.OnGameEnded?.Invoke();

        UnityEngine.SceneManagement.SceneManager.LoadScene("Results");
    }
}