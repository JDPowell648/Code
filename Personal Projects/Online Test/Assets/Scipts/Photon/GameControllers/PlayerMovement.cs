using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.IO;

public class PlayerMovement : MonoBehaviour {
    private static PlayerMovement something;

    Rigidbody2D rbody;
    private PhotonView PV;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        PV = GetComponent<PhotonView>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine)
            return;
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * 5;
        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
        Vector2 mousepos;
        mousepos = (Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized;
        transform.up = mousepos;
    }

}