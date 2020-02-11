using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    public void TestLevel1()
    {
        SceneManager.LoadScene("TestLevel1");
    }
    public void TestLevel2()
    {
        SceneManager.LoadScene("TestLevel2");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
