using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class ConectToServer : MonoBehaviourPunCallbacks
{
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Conectado al server?");

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado al server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Conectado al Lobby");
        SceneManager.LoadScene("Lobby");
    }

    //public override void OnJoinedRoom() {
    //    Debug.Log("Conectado a la sala");
    //    PhotonNetwork.LoadLevel("Game");
    //}

    //public override void OnJoinRandomFailed(short returnCode, string message)
    //{
    //    string roomName = "Room " + Random.Range(1000, 10000);

    //    RoomOptions options = new RoomOptions { MaxPlayers = 8 };

    //    PhotonNetwork.CreateRoom(roomName, options, null);
    //}
}
