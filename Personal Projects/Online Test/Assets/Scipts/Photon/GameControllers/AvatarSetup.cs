using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSetup : MonoBehaviour {
    private PhotonView PV;
    public int characterValue;
    public GameObject myChar;

    public int playerHealth;
    public int playerDamage;

    public GameObject myCamera;
    public GameObject CameraTransform;

	// Use this for initialization
	void Start () {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            PV.RPC("RPC_AddChar", RpcTarget.AllBuffered, PlayerInfo.PI.mySelectedCharacter);
            PV.RPC("createCamera", RpcTarget.AllBuffered);
        }
        else
        {
            Destroy(CameraTransform);
        }
	}
	
	[PunRPC]
    void RPC_AddChar(int whichChar)
    {
        characterValue = whichChar;
        myChar = Instantiate(PlayerInfo.PI.allCharacters[whichChar], transform.position, transform.rotation, transform);
    }

    [PunRPC]
    void createCamera()
    {
        CameraTransform = Instantiate(myCamera, new Vector3(transform.position.x, transform.position.y, transform.position.z - 10), new Quaternion(), null);
        CameraTransform.GetComponent<followplayer>().ParentPlayer = gameObject;
    }
}
