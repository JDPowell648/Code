using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks {

    public static PhotonLobby Lobby;

    public GameObject battleButton;
    public GameObject cancelButton;


    private void Awake()
    {
        Lobby = this;//Creates the singleton, lives within the Main menu screne

    }

    // Use this for initialization
    void Start () {
        PhotonNetwork.ConnectUsingSettings();//Connect to Master photon server

	}
	
    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connect to the Photon Master Server");
        battleButton.SetActive(true);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void OnBattleButtonClicked()
    {
        Debug.Log("Connect button was clicked");
        PhotonNetwork.JoinRandomRoom();
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join a random game but failed. There must be no rooms available");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("trying to create a room");
        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)MultiplayerSettings.multiplayerSettings.maxPlayers};
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("The room has been joined!");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a new room but failed, there must be a room with this name");
        CreateRoom();
    }

    public void OnCancelButtonClicked()
    {
        Debug.Log("cancel button was clicked");
        cancelButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
