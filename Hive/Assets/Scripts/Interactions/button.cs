using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    public int numberScene;

    public void Enter()
    {
        SceneManager.LoadScene(numberScene);
    }
}
