using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [Range(1, 10)]
    public float smoothFactor;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
}
