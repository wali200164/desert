using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;

    float rotationY = 0f; // keep track of horizontal rotation

    void Update()
    {
        // --- Mouse rotation ---
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        // Rotate the player horizontally
        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);

        // --- Movement ---
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Move relative to the player's facing direction
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
}
