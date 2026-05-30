using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;

    public float timeRemaining = 45f;

    private bool timerRunning = false;

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

    void Update()
    {
        if (GameManager.Instance.CurrentState != GameState.Playing)
            return;

        if (!timerRunning)
            return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            GameEvents.OnTimerChanged?.Invoke(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            timerRunning = false;

            GameManager.Instance.SetState(GameState.Results);
        }
    }

    public void StartTimer()
    {
        timerRunning = true;
    }
}