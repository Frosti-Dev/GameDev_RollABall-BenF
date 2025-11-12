using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI Version;
    void Start()
    {
        Version.text = $"Ver:{Application.version}"; 
    }
}
