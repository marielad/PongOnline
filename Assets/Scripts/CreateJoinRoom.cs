using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using UnityEngine.UI;

public class CreateJoinRoom : MonoBehaviourPunCallbacks
{
    private byte maxPlayersPerRoom = 2;
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public Button startGameButton;
    public GameObject waitTxt;
    private void Update()
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {

            startGameButton.gameObject.SetActive(true);
            waitTxt.SetActive(false);
        }
        else { 
            startGameButton.gameObject.SetActive(false); 
        }
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("NÚMERO DE JUGADORES: "+ PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.IsMasterClient)
        {
            waitTxt.SetActive(true);
        }
    }

    public void OnStartGameButtonClicked()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;

        PhotonNetwork.LoadLevel("Game");
    }
}
