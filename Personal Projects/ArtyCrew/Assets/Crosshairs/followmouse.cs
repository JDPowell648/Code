using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followmouse : MonoBehaviour {

    Vector3 pos;
    [SerializeField] float mousex;
    [SerializeField] float mousey;
    [SerializeField] float posx;
    [SerializeField] float posy;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = pos;
        Vector3 mousepos;
        mousepos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));

        mousex = mousepos.x;
        mousey = mousepos.y;
        posx = pos.x;
        posy = pos.y;

        if (Input.GetKey(KeyCode.Space) && fire.fired == false)
        {
            pos.x = mousepos.x;
            pos.y = mousepos.y;

        }
    }
}
