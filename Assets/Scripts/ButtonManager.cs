using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject levelSelection;

    private void Start()
    {
        levelSelection.SetActive(false);
    }

    public void OnPlayButton()
    {
        levelSelection.SetActive(true);
    }

    public void OnLevel1Button()
    {
        SceneManager.LoadScene(1);
    }


    public void OnLevel2Button()
    {
        SceneManager.LoadScene(2);
    }

    public void OnLevel3Button()
    {
        SceneManager.LoadScene(3);
    }
  
    
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
