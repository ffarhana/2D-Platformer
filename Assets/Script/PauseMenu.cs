using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    public GameObject saveMenu;

    public SaveSystem _SaveSystem;
    //gamemanager punya savecode start
    public static PauseMenu instance;


    private void Awake()
    {
        //// Ensure only one instance of GameManager exists
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
    //end

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");

    }

    public void SaveGame()
    {
        _SaveSystem.SavePlayerData();

        pauseMenu.SetActive(false); // Deactivate pause menu
    }



    public void BackToPauseMenu()
    {
        saveMenu.SetActive(false);  // Deactivate Save menu
        pauseMenu.SetActive(true);  // Activate pause menu
    }


    public void QuitGame() => Application.Quit();
}
                  