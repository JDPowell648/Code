using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour {
    
    [SerializeField] private GameObject shell;
    [SerializeField] private bool landed;
    private Vector3 prevPos;
    private bool shellfired;
    [SerializeField] private Transform Barrelpos;

    // Use this for initialization
    void Start () {
        landed = false;
        prevPos = transform.position;
    }

    private void Update()
    {
        if (shellfired == false)
        {
            shell.transform.position = Barrelpos.position;
            shell.transform.right = Barrelpos.up;
        }
        if (prevPos != transform.position)
            {
                Vector2 dir = (transform.position - prevPos) * -1;

                transform.up = dir;

                prevPos = transform.position;
            }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(shell);
    }
}
