using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowMessage(string message)
    {
        Debug.Log(message);
    }
}