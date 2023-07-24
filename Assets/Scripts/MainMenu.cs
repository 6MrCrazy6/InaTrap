using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int currentlevel;

    public void PlayGame()
    {
        if (!PlayerPrefs.HasKey("Levels")) currentlevel = 1;
        else currentlevel = PlayerPrefs.GetInt("Levels");
        SceneManager.LoadScene("Level " + currentlevel);
    }

    public void ExitGame()
    {
        Debug.Log("Game Close");
        Application.Quit();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
