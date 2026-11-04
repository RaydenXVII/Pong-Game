using UnityEngine;

public enum PaddleControl { Player1, Player2 }

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PaddleControl control = PaddleControl.Player1;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float yLimit = 4f;

    private Rigidbody2D rb;
    private PongControls controls;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PongControls();
    }

    private void OnEnable()  => controls.Gameplay.Enable();
    private void OnDisable() => controls.Gameplay.Disable();
    private void OnDestroy() => controls.Dispose();

    private void FixedUpdate()
    {
        float input = control == PaddleControl.Player1
            ? controls.Gameplay.Player1Move.ReadValue<float>()
            : controls.Gameplay.Player2Move.ReadValue<float>();

        float newY = rb.position.y + input * speed * Time.fixedDeltaTime;
        newY = Mathf.Clamp(newY, -yLimit, yLimit);
        rb.MovePosition(new Vector2(rb.position.x, newY));
    }
}