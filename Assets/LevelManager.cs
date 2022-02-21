using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public enum Levels { Menu = 0, Game = 1, GameOver = 2, Victory = 3, Records = 4 };

    public void CambiarLvl(Levels lvl)
    {
       SceneManager.LoadScene((int)lvl);
    }
    public void CambiarLvl(int indice)
    {
        SceneManager.LoadScene(indice);
    }

}
