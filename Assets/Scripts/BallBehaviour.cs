using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallBehaviour : MonoBehaviour
{
    public float speed = 10.0f;
    Vector3 direction;
    float originalSpeed;
    int scorePlayerOne;
    int scorePlayerTwo;

    public TextMeshProUGUI playerOneScore;
    public TextMeshProUGUI playerTwoScore;


    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = speed;
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (speed < 30)
        {
            speed += Time.deltaTime;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.PlayPongSound();
        if (collision.gameObject.tag.Equals("Wall")) {

            direction = new Vector3(direction.x, direction.y * Random.Range(-1f, 0f), 0f);

        } else if (collision.gameObject.tag.Equals("Player")) {

            direction = new Vector3(direction.x * -1.0f, direction.y * Random.Range(-1f, 1f) + 0.5f, 0f);

        }
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
        playerOneScore.text = scorePlayerOne.ToString();
        playerTwoScore.text = scorePlayerTwo.ToString();
        
        ResetBall();
    }

    void ResetBall() {
        speed = originalSpeed;
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1.5f, 1.5f), 0);
        transform.position = Vector3.zero;
    }

}
