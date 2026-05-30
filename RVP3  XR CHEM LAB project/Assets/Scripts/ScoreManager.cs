using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;

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

    public void AddScore(int amount)
    {
        score += amount;

        GameEvents.OnScoreChanged?.Invoke(score);

        Debug.Log("SCORE: " + score);
    }

    public void RemoveScore(int amount)
    {
        score -= amount;

        GameEvents.OnScoreChanged?.Invoke(score);

        Debug.Log("SCORE: " + score);
    }
}