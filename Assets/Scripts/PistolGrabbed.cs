using UnityEngine;
using Oculus.Interaction;

public class RotateOnGrab : MonoBehaviour
{
    private Grabbable interactable;
    private Transform originalParent;
    private bool isGrabbed = false;
    public Vector3 targetRotationEuler; // Target rotation in Euler angles

    void Start()
    {
        interactable = GetComponent<Grabbable>();

        if (interactable != null)
        {
            
        }
        else
        {
            Debug.LogError("Grabbable component not found on object: " + gameObject.name);
        }
    }

    void OnGrab()
    {
        isGrabbed = true;
        Quaternion targetRotation = Quaternion.Euler(targetRotationEuler);
        transform.rotation = targetRotation;
    }

    void OnRelease()
    {
        isGrabbed = false;
    }

    void Update()
    {
        if (isGrabbed)
        {
            // Use controller input to rotate the object
            float rotationSpeed = 100f; // Rotation speed
            float rotationX = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
            float rotationY = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, -rotationY, Space.World);
            transform.Rotate(Vector3.right, rotationX, Space.World);
        }
    }
}