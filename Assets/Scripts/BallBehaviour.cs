using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class BallBehaviour : MonoBehaviourPunCallbacks
{
    public float speed = 1000f;
    public TextMeshProUGUI playerOneScore;
    public TextMeshProUGUI playerTwoScore;
    public TextMeshProUGUI score;
    public GameObject winScreen;
    public Rigidbody2D rigidbody;
    
    PhotonView photonView;
    float originalSpeed;
    int scorePlayerOne;
    int scorePlayerTwo;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        photonView = gameObject.GetComponent<PhotonView>();
        originalSpeed = speed;
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
    }

    public void Launch() {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rigidbody.velocity = new Vector2(speed * x, speed * y);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.PlayPongSound();
        //    if (collision.gameObject.tag.Equals("Wall")) {

        //        direction = new Vector3(direction.x, direction.y * Random.Range(-1f, 0f), 0f);

        //    } else if (collision.gameObject.tag.Equals("Player")) {

        //        direction = new Vector3(direction.x * -1.0f, direction.y * Random.Range(-1f, 1f) + 0.5f, 0f);

        //    }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        AudioManager.instance.PlayGoalSound();

        if (col.gameObject.tag.Equals("Score"))
        {
            scorePlayerTwo++;
        }
        else if (col.gameObject.tag.Equals("ScoreTwo"))
        {
            scorePlayerOne++;
        }

        UpdateScore();

        if (scorePlayerOne == 3 || scorePlayerTwo == 3)
        {
            rigidbody.velocity = Vector2.zero;
            score.text = scorePlayerOne + " - " + scorePlayerTwo;
            winScreen.SetActive(true);
        }
        else {
            ResetBall();
        }

    }

    void ResetBall() {
        speed = originalSpeed;
        transform.position = Vector3.zero;
        Launch();
    }

    void UpdateScore()
    {
        playerOneScore.text = scorePlayerOne.ToString();
        playerTwoScore.text = scorePlayerTwo.ToString();
    }

    public void BackToLobby() {
        SceneManager.LoadScene("Lobby");
    }
}
