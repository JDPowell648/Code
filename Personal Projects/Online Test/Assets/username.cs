using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class username : MonoBehaviour {

    [SerializeField] private InputField UserNameInput;
    public static string PlayerName;
    private Scene currentScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerName = UserNameInput.text;
        DontDestroyOnLoad(gameObject);
        if (currentScene.buildIndex == 0)
        {
            Destroy(gameObject);
        }
	}
}
