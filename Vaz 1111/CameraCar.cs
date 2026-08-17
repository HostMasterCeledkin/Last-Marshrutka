using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float sensitivity = 3f;

    private float rotationX = 20f;
    private float rotationY = 0f;

    void LateUpdate()
    {
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;

        rotationX = Mathf.Clamp(rotationX, -20f, 80f);

        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);

        transform.position = target.position - rotation * Vector3.forward * distance;
        transform.rotation = rotation;
    }
}