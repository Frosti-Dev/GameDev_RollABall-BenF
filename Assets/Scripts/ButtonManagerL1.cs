using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerL1 : MonoBehaviour
{
    public void OnRetryButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnNextButton()
    {
        SceneManager.LoadScene(2);
    }

    public void OnQuitButton()
    {
        SceneManager.LoadScene(0);
    }
}
