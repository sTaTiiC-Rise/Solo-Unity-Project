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
    GameObject loseScreen;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            healthBar = GameObject.FindGameObjectWithTag("ui_health").GetComponent<Image>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            
            PauseMenu = GameObject.FindGameObjectWithTag("pause");
            PauseMenu.SetActive(false);
            loseScreen = GameObject.FindGameObjectWithTag("loseScreen");
            loseScreen.SetActive(false);
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


    public void Slain()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Slain");
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
            Debug.Log("paused");
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
