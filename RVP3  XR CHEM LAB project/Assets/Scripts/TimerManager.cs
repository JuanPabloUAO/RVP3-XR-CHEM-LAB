using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;

    public float timeRemaining = 45f;

    public bool timerRunning = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!timerRunning)
            return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
            timerRunning = false;

            Debug.Log("Tiempo terminado");
        }
    }
}