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

        float accel = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) ? 1f : 0f;
        float steer = 0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) steer = -1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) steer = 1f;

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
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && grounded)
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
