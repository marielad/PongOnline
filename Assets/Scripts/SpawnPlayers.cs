using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject playerPrefab2;

    public Vector3 spawnPos;
    public Vector3 spawnPos2;

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPos, Quaternion.identity);
        }
        else { 
            PhotonNetwork.Instantiate(playerPrefab2.name, spawnPos2, Quaternion.identity);
        }
    }

}
