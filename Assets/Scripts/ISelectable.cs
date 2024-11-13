using UnityEngine;

public interface ISelectable
{
    GameObject GetGameObject();
    void Unselect();
    void Select();
}