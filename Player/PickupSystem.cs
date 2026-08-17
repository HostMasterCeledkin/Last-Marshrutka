using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    [Header("Ссылки")]
    public Camera playerCamera;
    public Transform holdPoint;

    [Header("Настройки")]
    public float pickupDistance = 3f;
    public float throwForce = 5f;

    private Rigidbody heldObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObject == null)
                TryPickup();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropObject();
        }
    }

    void TryPickup()
    {
        Ray ray = playerCamera.ScreenPointToRay(
            new Vector3(Screen.width / 2f, Screen.height / 2f));

        if (Physics.Raycast(ray, out RaycastHit hit, pickupDistance))
        {
            PickupObject pickup = hit.collider.GetComponent<PickupObject>();

            if (pickup == null)
                return;

            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();

            if (rb == null)
                return;

            heldObject = rb;

            rb.isKinematic = true;
            rb.useGravity = false;

            rb.transform.SetParent(holdPoint);
            rb.transform.localPosition = Vector3.zero;
            rb.transform.localRotation = Quaternion.identity;

            Debug.Log("Поднят предмет: " + pickup.itemName);
        }
    }

    void DropObject()
    {
        if (heldObject == null)
            return;

        heldObject.transform.SetParent(null);

        heldObject.isKinematic = false;
        heldObject.useGravity = true;

        heldObject.AddForce(playerCamera.transform.forward * throwForce, ForceMode.Impulse);

        heldObject = null;
    }
}