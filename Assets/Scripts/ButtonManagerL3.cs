using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerL3 : MonoBehaviour
{
    public void OnRetryButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
        SceneManager.LoadScene(0);
    }
}
