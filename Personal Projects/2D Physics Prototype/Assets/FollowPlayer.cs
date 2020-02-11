using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offset;
    [SerializeField] private float maxHeight;
    [SerializeField] private float cameraHeight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > player.position.x)
        {
            Vector3 moveTowards = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = moveTowards;
        }
        else if (transform.position.x < player.position.x)
        {
            Vector3 moveTowards = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = moveTowards;
        }

        if (transform.position.y > player.position.y + offset)
        {
            Vector3 moveTowards = new Vector3(transform.position.x, player.position.y + offset, transform.position.z);
            transform.position = moveTowards;
        }
        else if (transform.position.y < player.position.y + offset && checkMaxHeight())
        {
            Vector3 moveTowards = new Vector3(transform.position.x, player.position.y + offset, transform.position.z);
            transform.position = moveTowards;
        }
    }

    private bool checkMaxHeight()
    {
        if (transform.position.y + (cameraHeight / 2) >= maxHeight)
        {
            return false;
        }
        return true;
    }
}
