using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleController : MonoBehaviour
{
    public CarTemplate template;
    public float speedMultiplier = 1f;
    public float handlingMultiplier = 1f;
    public float jumpForce = 5f;

    Rigidbody rb;
    bool grounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (template == null)
        {
            Debug.LogWarning("VehicleController: No CarTemplate assigned.");
        }
    }

    void FixedUpdate()
    {
        if (template == null) return;

        InputManager input = InputManager.Instance;
        float accel = input.GetAcceleration();
        float steer = input.GetSteer();

        // Move forward based on template.baseSpeed
        Vector3 forwardMove = transform.forward * accel * template.baseSpeed * speedMultiplier * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);

        // Simple rotation to steer
        if (steer != 0f)
        {
            transform.Rotate(0f, steer * template.handling * handlingMultiplier * Time.fixedDeltaTime, 0f);
        }
    }

    void Update()
    {
        InputManager input = InputManager.Instance;
        if (input.GetJumpInput() && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            grounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
}
