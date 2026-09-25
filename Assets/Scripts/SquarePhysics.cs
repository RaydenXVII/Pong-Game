using UnityEngine;

public class SquarePhysics : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 8f;
    [SerializeField] private float speedMultiplier = 1.05f; // Kecepatan meningkat tiap pantulan

    private Rigidbody2D rb;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("SquarePhysics butuh Rigidbody2D!");
            return;
        }

        Launch();
    }

    public void Launch()
    {
        currentSpeed = initialSpeed;

        // Pilih arah awal secara acak: kiri (-1) atau kanan (1)
        float directionX = Random.value < 0.5f ? -1f : 1f;

        // Beri sedikit variasi sudut vertikal agar tidak lurus kaku
        float directionY = Random.Range(-0.5f, 0.5f);

        Vector2 direction = new Vector2(directionX, directionY).normalized;
        rb.linearVelocity = direction * currentSpeed;
        // Catatan: Jika menggunakan Unity 2022 ke bawah, ganti 'linearVelocity' menjadi 'velocity'
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
        Launch();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Deteksi jika mengenai Paddle
        if (collision.gameObject.CompareTag("Player"))
        {
            // Hitung posisi benturan relatif terhadap tengah paddle
            float paddleCenterY = collision.transform.position.y;
            float paddleHeight = collision.collider.bounds.size.y;
            float hitFactor = (transform.position.y - paddleCenterY) / paddleHeight;

            // Pantulkan ke arah berlawanan dari sumbu X sebelumnya
            float dirX = rb.linearVelocity.x > 0 ? -1f : 1f;

            // Buat vektor arah baru berdasarkan titik benturan
            Vector2 bounceDirection = new Vector2(dirX, hitFactor * 2f).normalized;

            // Tambah kecepatan sedikit demi sedikit
            currentSpeed *= speedMultiplier;

            rb.linearVelocity = bounceDirection * currentSpeed;
        }
    }
}
