using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    private int currentSceneIndex;

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SavedLevel", currentSceneIndex);
            SceneManager.LoadScene(0);
            
        }
    }

   /* public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
       GameIsPaused = false;
    }

     public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void loadMenu()
    {
        Time.timeScale = 1f;
        // Debug.Log("menu loading/......");
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("quiting /......");
        Application.Quit();
    }*/
}
