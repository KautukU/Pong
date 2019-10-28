using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    int p1 = 0;
    int p2 = 0;
    public float speed = 5;
    private Rigidbody2D ball;
    public Text Scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            ball.velocity = new Vector2(-speed, 0f);
        }
        else if (rand == 1)
        {
            ball.velocity = new Vector2(speed, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.position.x > -9)
        {
            p1 += 1;

            ball.position = new Vector2(0f, 0f);
            ball.velocity = new Vector2(-speed, 0f);
        }
        if (ball.position.x < 9)
        {
            p2 += 1;

            ball.position = new Vector2(0f, 0f);
            ball.velocity = new Vector2(speed, 0f);
        }
        
        string str1 = p1.ToString();
        string str2 = p2.ToString();
        Scoreboard.text = str1 + "   -   " + str2;

        if (p1 != 4 && p2 != 4)
        {
            if (p1 == 5)
            {
                Scoreboard.text = "Player 1 has won";
                ball.transform.position = new Vector2(0, 0);
            }
            if (p2 == 5)
            {
                Scoreboard.text = "Player 2 has won";
                ball.transform.position = new Vector2(0, 0);
            }
        }
        else
        {
            if (p1 == 6)
            {
                Scoreboard.text = "Player 1 has won";
                ball.transform.position = new Vector2(0, 0);
            }
            if (p2 == 6)
            {
                Scoreboard.text = "Player 2 has won";
                ball.transform.position = new Vector2(0, 0);
            }
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        float leftbounce = ball.transform.position.y - GameObject.Find("LeftPaddle").transform.position.y;
        float rightbounce = ball.transform.position.y - GameObject.Find("RightPaddle").transform.position.y;

        if (collision.gameObject.name == "LeftPaddle")
        {
            ball.velocity = new Vector2(speed, leftbounce * 2f);
        }
        if (collision.gameObject.name == "RightPaddle")
        {
            ball.velocity = new Vector2(-speed, rightbounce * 2f);
        }




    }
}
