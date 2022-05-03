using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void BackToMenu ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void BackToMenuFromCredits()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void ToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void ToBossLVL2()
    {
        SceneManager.LoadScene("BossLVL2");
    }
}
