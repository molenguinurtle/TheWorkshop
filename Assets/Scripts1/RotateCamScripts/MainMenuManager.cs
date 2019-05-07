using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public RectTransform mainMenuScreen;
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void LoadEngineSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenControlsScreen()
    {
        Debug.Log("Controls Opened");
        mainMenuScreen.gameObject.SetActive(false);

    }

    public void OpenMainMenuScreen()
    {
        mainMenuScreen.gameObject.SetActive(true);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
