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

    [Header("Life Counters")]
    public GameObject counter1;
    public GameObject counter2;
    public GameObject counter3;

    AudioSource pauseAudio;
    public AudioClip pauseSound;


    // Start is called before the first frame update
    void Start()
    {
        if (pauseMenu)
        {
            pauseAudio = gameObject.AddComponent<AudioSource>();
            pauseAudio.clip = pauseSound;
            pauseAudio.loop = false;
        }
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
        if (counter1 && counter2 && counter3)
        {
            if (GameManager.instance.lives == 0)
            {
                counter1.SetActive(false);
                counter2.SetActive(false);
                counter3.SetActive(false);
            }
            else if (GameManager.instance.lives == 1)
            {
                counter1.SetActive(true);
                counter2.SetActive(false);
                counter3.SetActive(false);
            }
            else if (GameManager.instance.lives == 2)
            {
                counter1.SetActive(true);
                counter2.SetActive(true);
                counter3.SetActive(false);
            }
            else
            {
                counter1.SetActive(true);
                counter2.SetActive(true);
                counter3.SetActive(true);
            }
        }


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
                    pauseAudio.Play();
                    Time.timeScale = 1f;
                    GameIsPaused = false;
                }
                else
                {
                    pauseMenu.SetActive(true);
                    pauseAudio.Play();
                    Time.timeScale = 0f;
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
