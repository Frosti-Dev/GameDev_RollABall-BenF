using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerL2 : MonoBehaviour
{
    public void OnRetryButton()
    {
        SceneManager.LoadScene(2);
    }

    public void OnNextButton()
    {
        SceneManager.LoadScene(3);
    }

    public void OnQuitButton()
    {
        SceneManager.LoadScene(0);
    }
}
