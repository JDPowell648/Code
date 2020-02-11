using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontdestroy : MonoBehaviour {
    private static dontdestroy something;
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

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex <= 2)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
