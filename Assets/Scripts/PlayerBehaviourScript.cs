using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 600f;

    float move;
    Vector3 startPos;

    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        startPos = transform.position;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            move = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, move * speed);
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
    }
}
