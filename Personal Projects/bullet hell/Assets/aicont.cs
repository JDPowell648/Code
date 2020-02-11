using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aicont : MonoBehaviour {
    public Transform Parent;
	// Use this for initialization
	void Start () {
		
	}

    private void Update()
    {
        Parent.GetComponent<enemyscript>().enemyHealth.AIColl2D = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
            Parent.GetComponent<enemyscript>().enemyHealth.AIColl2D = true;
        }
    }
}
