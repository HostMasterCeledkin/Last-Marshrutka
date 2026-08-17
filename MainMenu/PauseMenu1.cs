using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu1 : MonoBehaviour
{
    [Header("Панель паузы")]
    public GameObject pausePanel;

    [Header("Кнопки")]
    public Button continueButton;
    public Button exitButton;

    [Header("Сцена для кнопки Exit")]
    public string exitSceneName = "MainMenu";

    private bool isPaused = false;

    private void Start()
    {
        pausePanel.SetActive(false);

        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(ContinueGame);

        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(ExitToScene);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;

        pausePanel.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ContinueGame()
    {
        isPaused = false;

        pausePanel.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ExitToScene()
    {
        // Возвращаем время в нормальное состояние
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Загружаем указанную сцену
        SceneManager.LoadScene(exitSceneName);
    }
}