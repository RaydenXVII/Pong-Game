using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) 
        {
            Debug.LogWarning("PlayerController butuh Rigidbody2D pada GameObject ini!");
        }
    }

    void FixedUpdate()
    {
        // Cegah NullReference jika perangkat keyboard belum terdeteksi
        if (Keyboard.current == null || rb == null) return;

        float moveY = 0f;

        // Input gerak atas dan bawah
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            moveY = 1f;
        }
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            moveY = -1f;
        }

        // Terapkan kecepatan vertikal (sumbu X tetap 0)
        rb.linearVelocity = new Vector2(0f, moveY * speed);
        // Catatan: Jika menggunakan Unity versi 2022 ke bawah, ubah 'linearVelocity' menjadi 'velocity'
    }
}