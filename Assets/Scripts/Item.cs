using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Collider collider;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private ItemView itemView;
    private bool _selected;
    
    public void Unselect()
    {
        if (!_selected)
        {
            return;
        }
        
        itemView.UnHighlight();
        _selected = false;
    }

    public void Select()
    {
        if (_selected)
        {
            return;
        }
        
        itemView.Highlight();
        _selected = true;
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