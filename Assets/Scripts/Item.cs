using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Item : MonoBehaviour, ISelectable
{
    public GameObject GetGameObject() => gameObject;

    public void Unselect()
    {
        Debug.Log("Selected");
    }

    public void Select()
    {
        Debug.Log("Unselected");
    }
}