using UnityEngine;

public class PersistentXRPlayer : MonoBehaviour
{
    private static PersistentXRPlayer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}