using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [Header("Buttons")]
    public Button startButton;
    public Button quitButton;
    public Button pauseQuitButton;
    public Button settingsButton;
    public Button backButton;
    public Button returnToMenuButton;
    public Button returnToGameButton;

    [Header("Text")]
    public Text livesText;
    public Text scoreText;
    public Text volText;
    public Text pauseVolText;
    public Text muteText;

    [Header("Menus")]
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject settingsMenu;

    [Header("Slider")]
    public Slider volSlider;
    public Slider pauseSlider;

    [Header("Toggles")]
    public Toggle muteToggle;


    // Start is called before the first frame update
    void Start()
    {
        if (startButton)
        {
            startButton.onClick.AddListener(() => GameManager.instance.StartGame());
        }
        if (quitButton)
        {
            quitButton.onClick.AddListener(() => GameManager.instance.QuitGame());
        }
        if (pauseQuitButton)
        {
            pauseQuitButton.onClick.AddListener(() => GameManager.instance.QuitGame());
        }
        if (returnToGameButton)
        {
            returnToGameButton.onClick.AddListener(() => ReturnToGame());
        }
        if (returnToMenuButton)
        {
            returnToMenuButton.onClick.AddListener(() => GameManager.instance.ReturnToMenu());
        }
        if (backButton)
        {
            backButton.onClick.AddListener(() => ShowMainMenu());
        }
        if (settingsButton)
        {
            settingsButton.onClick.AddListener(() => ShowSettingsMenu());
        }
        muteToggle.onValueChanged.AddListener((value) =>
        {
            ToggleListener(value);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu)
        {
            if (pauseMenu.activeSelf)
            {
                pauseVolText.text = pauseSlider.value.ToString();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (GameIsPaused)
                {
                    pauseMenu.SetActive(false);
                    Time.timeScale = 1f;
                    //gameAnimator.updateMode = AnimatorUpdateMode.Normal;
                    GameIsPaused = false;
                }
                else
                {
                    pauseMenu.SetActive(true);
                    Time.timeScale = 0f;
                    //gameAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
                    GameIsPaused = true;
                    
                    
                }
            }
        }
        if (livesText)
        {
            livesText.text = GameManager.instance.lives.ToString();
        }

        if (scoreText)
        {
            scoreText.text = GameManager.instance.score.ToString();
        }

        if (settingsMenu)
        {
            if (settingsMenu.activeSelf)
            {
                volText.text = volSlider.value.ToString();
            }
        }
    }

    public void ReturnToGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void ShowMainMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    void ShowSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ToggleListener(bool value)
    {
        if (value)
        {
            muteText.text = "Audio Disabled";
        }
        else
        {
            muteText.text = "";
        }
    }
}
