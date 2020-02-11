﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
	private static movement something;

	Rigidbody2D rbody;
    
	// Use this for initialization
	void Start () {

		rbody = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {

		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0);
		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime);

	}
}
