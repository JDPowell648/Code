using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour {

    [SerializeField] GameObject Parent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        Parent.transform.GetComponent<EnemyTestScript>().Reveal.Revealed = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Parent.transform.GetComponent<EnemyTestScript>().Reveal.Revealed = true;
    }
}
