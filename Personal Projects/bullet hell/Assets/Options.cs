using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour {

    private static Options something;
    [SerializeField] Slider Volume;
    [SerializeField] Text VolumeText;

    private void Awake()
    {
        if (something == null)
        {
            something = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start () {
		
	}
	
	void Update () {
        if (SceneManager.GetActiveScene().name == "Options")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        AudioListener.volume = Volume.normalizedValue;
        VolumeText.text = "Volume: " + Volume.value.ToString("#.") + "%";
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
