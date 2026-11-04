using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb2d;
    public float maxInitialAngle = 0.67f;
    public float moveSpeed = 1f;
    public float maxStartY= 4f;

    private float startX = 0f;
    void Start()
    {
        InitialPush(); 
    }

    private void InitialPush()
    {
        Vector2 dir = Random.value < 0.5f ? Vector2.left : Vector2.right;
        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb2d.linearVelocity = dir * moveSpeed;
    }

    private void ResetBall()
    {
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GoalController goalScored = collision.GetComponent<GoalController>();
        if(goalScored != null)
        {
            gameManager.OnScoreZoneReached(goalScored.id);
            ResetBall();
            InitialPush();
        }
    }
}
