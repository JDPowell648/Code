using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    private Vector3 prevPos;
    [SerializeField] private GameObject Barrel;
    [SerializeField] private Transform Barrelpos;
    [SerializeField] public static bool fired;
    [SerializeField] private bool fireed;
    [SerializeField] public Vector2 velocity;
    [SerializeField] private Transform CrosshairLocation;
    public float velocityf;
    Rigidbody2D rb;
    public GameObject shell;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fired = false;
        prevPos = transform.position;
    }

    void Update()
    {
        
        fireed = fired;
        if (fired == false)
        {
            transform.position = Barrelpos.position;
            transform.right = Barrelpos.transform.up;
        }
        if (Input.GetMouseButtonDown(1) && fired == false)
        {
            OnFired();
        }
        if (fired == true && boom.landed == false)
        {
            shell.SetActive(true);
            if (prevPos != transform.position)
            {
                Vector2 dir = (transform.position - prevPos)*-1;

                transform.up = dir;

                prevPos = transform.position;
            }
        }
        if (fired == true && boom.landed == true)
        {
            rb.velocity = (transform.position)*0;
        }
    

    }

    public void OnFired()
    {
        fired = true;
        rb.velocity = (CrosshairLocation.position - transform.position)*velocityf;

    }
}
