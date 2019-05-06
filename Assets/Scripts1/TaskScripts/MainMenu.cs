using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuButton; //The button that takes us back to the main menu
    public GameObject buttonPanel; //The panel of buttons that load the various tasks
    public static MainMenu instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);

    }

    public void LoadScene(string sceneName)
    {
        buttonPanel.SetActive(sceneName == "Menu");
        SceneManager.LoadScene(sceneName);
        menuButton.SetActive(sceneName != "Menu");
    }
}
