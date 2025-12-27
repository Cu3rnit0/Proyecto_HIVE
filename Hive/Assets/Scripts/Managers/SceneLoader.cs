using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadOffice()
    {
        SceneManager.LoadScene("Office_Test");
    }

    public void loadConferenceRoom()
    {
        SceneManager.LoadScene("ConferenceRoom_Test");
    }
}
