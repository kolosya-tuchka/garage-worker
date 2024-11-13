using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Transform holdPosition;
    [SerializeField] private ItemHold itemHold;
    [SerializeField] private ItemCheck itemCheck;

    private GameObject HeldItem
    {
        get => itemHold.HeldItem;
        set => itemHold.HeldItem = value;
    }
    private ISelectable SelectedItem => itemCheck.SelectedItem;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (HeldItem is null && SelectedItem is not null)
            {
                PickupItem();
            }
            else if (HeldItem is not null)
            {
                DropItem();
            }
        }
    }

    private void PickupItem()
    {
        if (SelectedItem == null)
        {
            return;
        }

        HeldItem = SelectedItem.GetGameObject();
        SelectedItem.Unselect();

        HeldItem.GetComponent<Collider>().enabled = false;
        HeldItem.transform.position = holdPosition.position;
        HeldItem.transform.parent = holdPosition;
    }

    private void DropItem()
    {
        HeldItem.transform.parent = null;
        HeldItem.GetComponent<Collider>().enabled = true;
        HeldItem = null;
    }
}