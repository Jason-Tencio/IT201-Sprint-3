using UnityEngine;

public class PickUpAndThrow : MonoBehaviour
{
    public Transform holdPosition; 
    public float pickUpRange = 2f; 
    public float throwForce = 10f;
    private GameObject heldObject; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObject == null)
            {
                TryPickUpObject();
            }
            else
            {
                ThrowObject();
            }
        }
    }

    void TryPickUpObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickUpRange))
        {
            if (hit.collider.CompareTag("Pushable"))
            {
                heldObject = hit.collider.gameObject;

                Rigidbody rb = heldObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.parent = holdPosition;
            }
        }
    }

    void ThrowObject()
    {
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; 
            heldObject.transform.parent = null; 

            rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        }
        heldObject = null;
    }
}
