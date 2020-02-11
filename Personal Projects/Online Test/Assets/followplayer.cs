using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour {

    public GameObject ParentPlayer;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(ParentPlayer.transform.position.x, ParentPlayer.transform.position.y, ParentPlayer.transform.position.z - 10);
	}
}
