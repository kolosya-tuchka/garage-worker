using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Item : MonoBehaviour
{
    [SerializeField] private Collider collider;
    [SerializeField] private Rigidbody rigidbody;

    public void Unselect()
    {
        Debug.Log("Selected");
    }

    public void Select()
    {
        Debug.Log("Unselected");
    }

    public void Pickup()
    {
        collider.enabled = false;
        rigidbody.isKinematic = true;
    }

    public void Drop(Vector3 dropForce)
    {
        collider.enabled = true;
        rigidbody.isKinematic = false;
        
        rigidbody.AddForce(dropForce, ForceMode.Impulse);
    }
}