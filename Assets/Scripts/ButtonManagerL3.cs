using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerL3 : MonoBehaviour
{
    public void OnRetryButton()
    {
        SceneManager.LoadScene(3);
    }

    public void OnNextButton()
    {
        SceneManager.LoadScene(4);
    }

    public void OnQuitButton()
    {
        SceneManager.LoadScene(0);
    }
}
