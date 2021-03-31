
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config param
    [SerializeField] Paddle paddle1;
    [SerializeField] Vector2 ballVelocity;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    // state
    bool hasStarted;

    //cached component references
    AudioSource myAdudioSource;
    Vector2 paddleToBallVector;
    Rigidbody2D myRidgedBody;

    // Start is called before the first frame update
    void Start()
    {
        hasStarted = false;
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAdudioSource = GetComponent<AudioSource>();
        myRidgedBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(ballVelocity.x, ballVelocity.y);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(
            paddle1.transform.position.x,
            paddle1.transform.position.y);

        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityAdjust = new Vector2(
            Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAdudioSource.PlayOneShot(clip);
            myRidgedBody.velocity += velocityAdjust;
        }
    }
}
