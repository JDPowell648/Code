using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionControl : MonoBehaviour {

    Vector3 Position;
    [SerializeField] private float timer;

	void Start ()
    {
        Position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Position;
        if (Input.GetKey(KeyCode.D))
        {
            timer = timer + Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.D) && timer < 2)
        {
            Position.x = Position.x + 0.64f;
        }
        if (Input.GetKey(KeyCode.D) && timer > .5)
        {
            Position.x = Position.x + 0.64f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            timer = timer + Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.A) && timer < 2)
        {
            Position.x = Position.x - 0.64f;
        }
        if (Input.GetKey(KeyCode.A) && timer > .5)
        {
            Position.x = Position.x - 0.64f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            timer = timer + Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.W) && timer < 2)
        {
            Position.y = Position.y + 0.64f;
        }
        if (Input.GetKey(KeyCode.W) && timer > .5)
        {
            Position.y = Position.y + 0.64f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            timer = timer + Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.S) && timer < 2)
        {
            Position.y = Position.y - 0.64f;
        }
        if (Input.GetKey(KeyCode.S) && timer > .5)
        {
            Position.y = Position.y - 0.64f;
        }
        /*
        else if (Input.GetKey(KeyCode.A))
        {
            if (timer % 2 == 0)
            {
                Position.x = Position.x - 0.64f;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (timer % 2 == 0)
            {
                Position.y = Position.y + 0.64f;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (timer % 2 == 0)
            {
                Position.y = Position.y - 0.64f;
            }
        }
        else
        {
            transform.position = Position;
        }*/

    }
}
