using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	private static CameraFollow something;
	public Transform shell;
    public Transform tank;
	
	// Use this for initialization
	void Start () {

    }

	// Update is called once per frame
	void Update () {
        if (tank && fire.fired == false)
        {
            transform.position = Vector3.Lerp(transform.position, tank.position, 1f) + new Vector3(7, 5, -5);

        }
        if (shell && fire.fired == true){
			transform.position = Vector3.Lerp(transform.position, shell.position, 1f) + new Vector3(0, 0, -5);
	}/*
        if (tank && boom.landed == true)
        {
            transform.position = Vector3.Lerp(transform.position, tank.position, 1f) + new Vector3(0, 0, -5);

        }*/
}
}
