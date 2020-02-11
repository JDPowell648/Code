using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private GameObject selectioncontrol;
    Vector3 Position;
    // Use this for initialization
    void Start () {
        selectioncontrol = GameObject.Find("SelectionControl");
        Position = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Position;
        if (selectioncontrol.transform.position.x > (transform.position.x - 3.25))
        {
            Position.x = Position.x + 0.64f;
            transform.position = Position;
        }
        if (selectioncontrol.transform.position.x < (transform.position.x + 2.75))
        {
            Position.x = Position.x - 0.64f;
            transform.position = Position;
        }
        if (selectioncontrol.transform.position.y > (transform.position.y - 2))
        {
            Position.y = Position.y + 0.64f;
            transform.position = Position;
        }
        if (selectioncontrol.transform.position.y < (transform.position.y + 1.75))
        {
            Position.y = Position.y - 0.64f;
            transform.position = Position;
        }
    }
}
