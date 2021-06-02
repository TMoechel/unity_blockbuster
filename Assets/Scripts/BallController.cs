using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Variable mit Zugriff auf das PaddleController Script
    [SerializeField] PaddleController paddle;
    [SerializeField] float speedX = 2f;
    [SerializeField] float speedY = 10f;
    [SerializeField] AudioClip[] ballSounds;

    Vector2 distancePaddleToBall;
    bool hasStarted= false;

    // Start is called before the first frame update
    void Start()
    {
        // Abstandsvektor zwischen Ball und Paddle = Vektor des Balls - Vektor des Paddles
        distancePaddleToBall = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            ShootBallOnMouseClick();
        }
    }

    private void ShootBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speedX, speedY);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + distancePaddleToBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            // generiert eine Zufallszahl von 0 bis 4 (0,1,2,3,4)
            int randomNumber = UnityEngine.Random.Range(0, ballSounds.Length);
            AudioClip clip = ballSounds[randomNumber];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
