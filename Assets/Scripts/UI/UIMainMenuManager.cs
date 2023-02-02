using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject SettingsPanel;

    public static UIMainMenuManager Instance => _instance;
    static UIMainMenuManager _instance;

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToggleSettings(bool toggle)
    {
        SettingsPanel.SetActive(toggle);
    }
}
