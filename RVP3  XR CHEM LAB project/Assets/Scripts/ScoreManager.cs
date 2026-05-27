using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int currentScore;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int amount)
    {
        currentScore += amount;

        Debug.Log("Score: " + currentScore);
    }

    public void RemoveScore(int amount)
    {
        currentScore -= amount;

        Debug.Log("Score: " + currentScore);
    }
}