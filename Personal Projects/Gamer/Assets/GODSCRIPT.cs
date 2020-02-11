using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GODSCRIPT : MonoBehaviour {

    //followcrosshair
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject Crosshair;
    [SerializeField] private Transform CrosshairLocation;
    [SerializeField] private float gunangle;
    //boom
    [SerializeField] private GameObject explosion;
    [SerializeField] private bool landed;
    //fire
    [SerializeField] private GameObject Barrel;
    [SerializeField] private Transform Barrelpos;
    [SerializeField] private bool shellfired;
    [SerializeField] private bool loaded;
    [SerializeField] private float velocityf;
    Rigidbody2D rb;
    [SerializeField] private GameObject shell;
    [SerializeField] private float reloadtimer;
    [SerializeField] private float reloadspeed;
    [SerializeField] private float movespeed;
    //followmouse
    Vector3 pos;
    //original
    [SerializeField] private bool isselected;
    private SpriteRenderer Sprite;
    [SerializeField] private Transform shellpos;
    private Vector3 prevPos;
    Rigidbody2D rbody;

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        Sprite = transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>();
        isselected = false;
        Crosshair.SetActive(false);
        //followcrosshair
        //boom
        landed = false;
        //fire
        rb = shell.GetComponent<Rigidbody2D>();
        loaded = true;
        //followmouse
        prevPos = shellpos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Selection.selection == transform)
        {
            isselected = true;
            Sprite.color = Color.red;
        }
        else
        {
            isselected = false;
            Sprite.color = Color.white;
        }
        //followcrosshair
        gunangle = Gun.transform.localRotation.eulerAngles.z;
        Gun.transform.right = (CrosshairLocation.position - Gun.transform.position).normalized;
        //boom
        //fire
        if (Input.GetMouseButtonDown(1) && loaded == true && isselected == true && !shellfired)
        {
            OnFired();
        }
        //followmouse
        if (isselected == true && loaded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                
                reloadtimer = reloadspeed;
                Crosshair.SetActive(true);
                Crosshair.transform.position = pos;
                Vector3 mousepos;
                mousepos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
                pos.x = mousepos.x;
                pos.y = mousepos.y;

                if (shellfired == false)
                {
                    shellpos.transform.position = Barrelpos.position;
                    shellpos.transform.right = Barrelpos.up;
                }

            }
            else
            {
                Crosshair.SetActive(false);
            }
        }
        else
        {
            Crosshair.SetActive(false);
        }
        if (shellfired == false)
        {
            shellpos.transform.position = Barrelpos.position;
            shellpos.transform.right = Barrelpos.up;
        }
        if (prevPos != shellpos.transform.position && shellfired == true)
        {
            Vector2 dir = (shellpos.transform.position - prevPos) * -1;

            shellpos.transform.up = dir;

            prevPos = shellpos.transform.position;
        }
        if (reloadtimer > 0)
        {
            reloadtimer -= Time.deltaTime;
        }
        if(reloadtimer <= 0)
        {
            loaded = true;
            shellfired = false;
        }
        if(isselected == true)
        {
            Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime * movespeed);
        }
    }
//fired
    void OnFired()
    {

        if (shellfired == false)
        {
            shellpos.transform.position = Barrelpos.position;
            shellpos.transform.right = Barrelpos.up;
        }
        shellfired = true;
        shellpos.transform.up = Barrelpos.transform.position - shellpos.transform.position;
        shellfired = true;
        loaded = false;
        rb.velocity = (CrosshairLocation.position - shellpos.transform.position) * velocityf;
    }
}
