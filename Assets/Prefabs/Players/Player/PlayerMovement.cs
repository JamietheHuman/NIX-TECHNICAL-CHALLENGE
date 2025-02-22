using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpHeight = 3f;

    private CharacterController controller;
    private Vector3 velocity;
    private static bool lockPlayer = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public static void LockPlayer(bool value)
    {
        lockPlayer = value;
    }

    void Update()
    {
        if (lockPlayer)
            return;

        // Ground Check
        bool isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small downward force to keep grounded
        }

        // Player Movement
        Vector3 moveDirection = transform.right * Input.GetAxis("Horizontal") +
                                transform.forward * Input.GetAxis("Vertical");
        controller.Move(moveDirection * _speed * Time.deltaTime);

        // Jump Logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        // Apply Gravity
        velocity.y += _gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
