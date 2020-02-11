using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarCombat : MonoBehaviour {
    private PhotonView PV;
    private AvatarSetup avatarSetup;
    public Transform rayOrigin;
    public LayerMask PlayerLayer;

    // Use this for initialization
    void Start() {
        PV = GetComponent<PhotonView>();
        avatarSetup = GetComponent<AvatarSetup>();
        rayOrigin = transform;
    }

    // Update is called once per frame
    void Update() {
        if (!PV.IsMine)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            PV.RPC("doDamage", RpcTarget.All);
        }
    }

    [PunRPC]
    void doDamage()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, rayOrigin.up, Mathf.Infinity, PlayerLayer);
        Debug.DrawRay(rayOrigin.position, rayOrigin.up * 1000, Color.white);
        if (hit.transform != null && hit.collider.tag == "Player")
        {
            Debug.Log("Hit!");
            Debug.DrawRay(rayOrigin.position, rayOrigin.up * 1000, Color.blue);
            hit.transform.GetComponent<AvatarSetup>().playerHealth -= avatarSetup.playerDamage;
        }
        else
        {
            Debug.Log("Did not Hit!");
        }
    }
    
}
