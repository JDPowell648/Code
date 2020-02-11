using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEnabled : MonoBehaviour {
    private static UIEnabled something;
    [SerializeField] GameObject menus;
    // Use this for initialization
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
	
	// Update is called once per frame
	void Update () {

        if (SceneManager.GetActiveScene().buildIndex <= 2)
        {
            menus.SetActive(false);
        }
        else
        {
            menus.SetActive(true);
        }
    }
}
