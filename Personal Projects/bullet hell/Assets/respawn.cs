using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemychase;
    [SerializeField] GameObject enemypath;
    [SerializeField] Transform one;
    [SerializeField] Transform two;
    [SerializeField] Transform three;
    [SerializeField] Transform basee;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Transform spawntransformone = Instantiate(enemychase, one.position, new Quaternion(), null).transform;
            Transform spawntransformbase = Instantiate(enemy, basee.position, new Quaternion(), null).transform;
            Transform spawntransformtwo = Instantiate(enemypath, two.position, new Quaternion(), null).transform;
            Transform spawntransformthree = Instantiate(enemypath, three.position, new Quaternion(), null).transform;
        }
    }
}
