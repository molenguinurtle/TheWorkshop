using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
#region Vars
    [SerializeField] private int _rotateClicks; //The number of times the User has clicked the Rotate Button
    [SerializeField] private int _flipClicks; //The number of times the User has used the Flip Switch
    public static GameManager Instance; //Our Instance of GameManager
    public RectTransform TryAgainPanel; //The UI Panel which holds the "Try again?" dialogue box
    public Text RotateCount; //UI object displaying _rotateClicks
    public Text FlipCount; //UI object displaying _flipClicks
    #endregion

    //This script is for tracking the clicks/interactions, then bringing up the "Try again?" Dialogue Box when appropriate
#region Methods
    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Enables the "Try again?" Dialogue Box
    /// </summary>
    private void EnableTryAgain()
    {
        //Enable the "Try again?" Dialogue Box. The 'Yes' Button on that will call the Reset methods here and in RotationManager
        if (TryAgainPanel)
            TryAgainPanel.gameObject.SetActive(true);
        else
            Debug.LogError("TryAgainPanel is not set! Have you set it in the Inspector?", TryAgainPanel);
    }

    /// <summary>
    /// Resets the game parameters including click counts
    /// </summary>
    public void Reset()
    {
        _rotateClicks = 0;
        _flipClicks = 0;
        RotateCount.text = _rotateClicks.ToString();
        FlipCount.text = _flipClicks.ToString();
        TryAgainPanel.gameObject.SetActive(false);
    }

    /// <summary>
    /// Closes the Application
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Pressed 'No.' Closing Application.");
        Application.Quit();
    }

    /// <summary>
    /// Updates the number of times the User has clicked the Rotate Button and determines if we should end game
    /// </summary>
    public void UpdateRotateCount()
    {
        _rotateClicks++;
        RotateCount.text = _rotateClicks.ToString();
        if ((_rotateClicks + _flipClicks) >= 10)
        {
            EnableTryAgain();
        }
    }

    /// <summary>
    /// Updates the number of times the User has used the Flip Switch and determines if we should end game
    /// </summary>
    public void UpdateFlipCount()
    {
        _flipClicks++;
        FlipCount.text = _flipClicks.ToString();
        if ((_rotateClicks + _flipClicks) >= 10)
        {
            EnableTryAgain();
        }
    }
#endregion

}
