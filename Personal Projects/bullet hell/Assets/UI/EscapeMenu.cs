using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour {
    public static bool paused;
    [SerializeField] InputField Codes;
    [SerializeField] GameObject Polka;
    private bool PolkaTime;

    void Start()
    {
        paused = false;
    }
    void Update()
    {
        if (transform.GetChild(0).gameObject.active == true)
        {
            paused = true;
        }
        if (Codes.text == "Polka" && PolkaTime == false)
        {
            Polka.SetActive(true);
            VictoryMarks.Cash = VictoryMarks.Cash + 100000;
            PolkaTime = true;
        }
        if (Input.GetKeyUp(KeyCode.Escape) && paused == false)
        {
            AudioListener.volume = 0;
            Time.timeScale = 0;
            transform.GetChild(0).gameObject.SetActive(true);
            paused = true;
        }
        else
        if (Input.GetKeyUp(KeyCode.Escape) && paused == true)
        {
            AudioListener.volume = 1;
            paused = false;
            Time.timeScale = 1;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void EscapeMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Debug.Log("QUITTING GAME");
        Application.Quit();
    }
}
