using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    private CharacterController controller;
    private Transform cameraTransform;
    private float verticalVelocity;
    private float xRotation = 0f;

    private bool isActive = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;

        // Activăm doar dacă suntem în scena ScenaExterior
        if (SceneManager.GetActiveScene().name == "ScenaExterior" )
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isActive = true;
        }
        else
        {
            // Eliberăm cursorul în alte scene
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isActive = false;
        }
    }

    void Update()
    {
        if (!isActive) return; // Nu face nimic dacă nu e în scena corectă

        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(2f * -gravity * jumpHeight);
            }
            else
            {
                verticalVelocity = -2f;
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        direction.y = verticalVelocity;

        controller.Move(direction * speed * Time.deltaTime);
    }
}