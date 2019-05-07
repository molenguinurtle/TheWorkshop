using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelManager : MonoBehaviour {

    public GameObject[] theEngines;
    public CameraController theCamera;
    public Text[] metricTexts;
    public RectTransform pauseMenuCanvas;
    public RectTransform pauseMenuOptions;
    public InputControl theControls; 
    private int _engineNum;
    private float currentAppTime;
    private float currentEngineTime;
    private int currentEngineViews;
    private float recordTimer;
    void Start ()
    {
        _engineNum = PlayerPrefs.GetInt("SelectedEngine", 0) + 1;
        currentAppTime = PlayerPrefs.GetFloat("AppTime", 0f);
        currentEngineTime = PlayerPrefs.GetFloat("Engine" + _engineNum + "Time", 0f);
        currentEngineViews = PlayerPrefs.GetInt("Engine" + _engineNum + "Total", 0);
        theEngines[PlayerPrefs.GetInt("SelectedEngine", 0)].SetActive(true);
        theCamera.target = theEngines[PlayerPrefs.GetInt("SelectedEngine", 0)].transform;
        SetUpDataTracking();
	}

    private void SetUpDataTracking()
    {
        metricTexts[0].text = "Total App Time:"+ "\r\n" + PlayerPrefs.GetFloat("AppTime", 0f).ToString("0.00");
        metricTexts[1].text = "Engine "+ _engineNum + " View Time:" + "\r\n" + PlayerPrefs.GetFloat("Engine"+_engineNum+"Time", 0f).ToString("0.00");
        metricTexts[2].text = "Engine " + _engineNum + " Views:" + "\r\n" + PlayerPrefs.GetInt("Engine" + _engineNum + "Total", 0).ToString();
    }

    // Update is called once per frame
    void Update ()
    {
        recordTimer += Time.deltaTime;
        currentAppTime += Time.deltaTime;
        currentEngineTime += Time.deltaTime;
        if (recordTimer >=1.0f)
        {
            //Record the new data in PlayerPrefs and update the UI
            currentEngineViews += UnityEngine.Random.Range(0, 5);
            PlayerPrefs.SetFloat("AppTime", currentAppTime);
            PlayerPrefs.SetFloat("Engine" + _engineNum + "Time", currentEngineTime);
            PlayerPrefs.SetInt("Engine" + _engineNum + "Total", currentEngineViews);
            SetUpDataTracking();
            recordTimer = 0;
        }
        Pause();
        SwitchEngines();
	}

    private void SwitchEngines()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _engineNum !=1)
        {
            theEngines[_engineNum - 1].SetActive(false);
            PlayerPrefs.SetInt("SelectedEngine", 0);
            _engineNum = 1;
            currentEngineTime = PlayerPrefs.GetFloat("Engine" + _engineNum + "Time", 0f);
            currentEngineViews = PlayerPrefs.GetInt("Engine" + _engineNum + "Total", 0);
            theEngines[PlayerPrefs.GetInt("SelectedEngine", 0)].SetActive(true);
            theCamera.target = theEngines[PlayerPrefs.GetInt("SelectedEngine", 0)].transform;
            SetUpDataTracking();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && _engineNum != 2)
        {
            theEngines[_engineNum - 1].SetActive(false);
            PlayerPrefs.SetInt("SelectedEngine", 1);
            _engineNum = 2;
            currentEngineTime = PlayerPrefs.GetFloat("Engine" + _engineNum + "Time", 0f);
            currentEngineViews = PlayerPrefs.GetInt("Engine" + _engineNum + "Total", 0);
            theEngines[PlayerPrefs.GetInt("SelectedEngine", 0)].SetActive(true);
            theCamera.target = theEngines[PlayerPrefs.GetInt("SelectedEngine", 0)].transform;
            SetUpDataTracking();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && _engineNum != 3)
        {
            theEngines[_engineNum - 1].SetActive(false);
            PlayerPrefs.SetInt("SelectedEngine", 2);
            _engineNum = 3;
            currentEngineTime = PlayerPrefs.GetFloat("Engine" + _engineNum + "Time", 0f);
            currentEngineViews = PlayerPrefs.GetInt("Engine" + _engineNum + "Total", 0);
            theEngines[PlayerPrefs.GetInt("SelectedEngine", 0)].SetActive(true);
            theCamera.target = theEngines[PlayerPrefs.GetInt("SelectedEngine", 0)].transform;
            SetUpDataTracking();
        }
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("We're paused.");
            Time.timeScale = 0;
            theControls.paused = true;
            pauseMenuCanvas.gameObject.SetActive(true);
        }
    }
    public void PauseControlsOpen()
    {
        pauseMenuOptions.gameObject.SetActive(false);
    }
    public void PauseControlsClose()
    {
        pauseMenuOptions.gameObject.SetActive(true);
    }
    public void UnPause()
    {
        Debug.Log("We're unpaused!");
        Time.timeScale = 1;
        theControls.paused = false;
        pauseMenuCanvas.gameObject.SetActive(false);
    }
    public void InGameQuit()
    {
        Application.Quit();
    }
}
