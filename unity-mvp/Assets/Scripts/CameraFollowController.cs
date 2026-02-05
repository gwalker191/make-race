using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public Transform target;
    public float distance = 10f;
    public float height = 5f;
    public float lookAheadDist = 5f;
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // Position camera behind and above the car
        Vector3 desiredPos = target.position - target.forward * distance + Vector3.up * height;
        transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * smoothSpeed);

        // Look ahead of the car
        Vector3 lookTarget = target.position + target.forward * lookAheadDist;
        transform.LookAt(lookTarget);
    }
}
