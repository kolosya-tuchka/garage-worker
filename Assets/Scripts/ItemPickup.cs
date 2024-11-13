using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Transform holdPosition;
    [SerializeField] private ItemHold itemHold;
    [SerializeField] private ItemCheck itemCheck;

    private Item HeldItem
    {
        get => itemHold.HeldItem;
        set => itemHold.HeldItem = value;
    }
    private Item SelectedItem => itemCheck.SelectedItem;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (HeldItem is null && SelectedItem is not null)
            {
                PickupItem();
            }
        }
    }

    private void PickupItem()
    {
        if (SelectedItem is null)
        {
            return;
        }

        HeldItem = SelectedItem;
        SelectedItem.Unselect();

        HeldItem.transform.position = holdPosition.position;
        HeldItem.transform.parent = holdPosition;
        HeldItem.Pickup();
    }
}