using System;
using UnityEngine;

public class ItemCheck : MonoBehaviour
{
    [SerializeField] private float pickupRange = 2f;
    [SerializeField] private Transform directionObject;
    [SerializeField] private ItemHold itemHold;
    
    public ISelectable SelectedItem { get; private set; }

    private void Update()
    {
        if (itemHold.HeldItem is not null)
        {
            SelectedItem?.Unselect();
            return;
        }
        CheckForItem();
    }

    private void CheckForItem()
    {
        var ray = new Ray(directionObject.position, directionObject.forward);

        if (Physics.Raycast(ray, out var hit, pickupRange))
        {
            if (hit.transform.TryGetComponent(out ISelectable item))
            {
                if (SelectedItem != item)
                {
                    SelectedItem?.Unselect();
                    SelectedItem = item;
                    SelectedItem.Select();
                }
            }
            else
            {
                SelectedItem?.Unselect();
                SelectedItem = null;
            }
        }
        else
        {
            SelectedItem?.Unselect();
            SelectedItem = null;
        }
    }    
}