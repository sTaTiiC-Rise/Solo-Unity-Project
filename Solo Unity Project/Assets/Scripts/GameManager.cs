using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    Image healthBar;
    PlayerMovement player;

    GameObject PauseMenu;
    public bool isPaused = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            healthBar = GameObject.FindGameObjectWithTag("ui_health").GetComponent<Image>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

            PauseMenu = GameObject.FindGameObjectWithTag("pause");
            PauseMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            healthBar.fillAmount = (float)player.health / (float)player.maxHealth;
        }
    }

    public void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;

            PauseMenu.SetActive(true);

            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
            Resume();
    }

    public void Resume()
    {
        if (isPaused)
        {
            isPaused = false;

            PauseMenu.SetActive(false);

            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadLevel(int level)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }
    public void MainMenu()
    {
        LoadLevel(0);
    }


}
