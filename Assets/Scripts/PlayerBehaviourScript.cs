using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{

    public KeyCode upKey;
    public KeyCode downKey;
    public float speed = 6.0f;
    float limit = 2.3f;
    float limitDown = -3.6f;

    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine){
       //move
       }
    }
}
