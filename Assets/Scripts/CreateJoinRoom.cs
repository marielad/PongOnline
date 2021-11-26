using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using UnityEngine.UI;

public class CreateJoinRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private byte maxPlayersPerRoom = 2;
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public Button startGameButton;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
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
        if (PhotonNetwork.CurrentRoom.PlayerCount != 2)
        {
            //WaitingOponent
        }
        else
        {
                startGameButton.gameObject.SetActive(true);
        }
    }

    public void OnStartGameButtonClicked()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;

        PhotonNetwork.LoadLevel("Game");
    }
}
