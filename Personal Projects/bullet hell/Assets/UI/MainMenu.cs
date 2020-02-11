using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Debug.Log("QUITTING GAME");
        Application.Quit();
    }

}
