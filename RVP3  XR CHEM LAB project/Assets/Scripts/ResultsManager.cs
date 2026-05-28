using UnityEngine;

public class ResultsManager : MonoBehaviour
{
    public static ResultsManager Instance;

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

    public string GetRank(int score)
    {
        if (score >= 90)
            return "Cientifico Experto";

        if (score >= 70)
            return "Investigador";

        return "Asistente";
    }
}
