using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ExitGame()
    {
        Debug.Log("Game Close");
        Application.Quit();
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
