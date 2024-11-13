using System;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private ItemHold itemHold;
    [SerializeField] private Transform dropPosition;
    [SerializeField] private Transform dropDirection;
    [SerializeField] private float dropForce = 10f;

    private Item HeldItem
    {
        get => itemHold.HeldItem;
        set => itemHold.HeldItem = value;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (HeldItem is not null)
            {
                DropItem();
            }
        }
    }

    private void DropItem()
    {
        HeldItem.transform.parent = null;
        HeldItem.transform.position = dropPosition.position;
        
        HeldItem.Drop(dropDirection.forward.normalized * dropForce);
        HeldItem = null;
    }
}