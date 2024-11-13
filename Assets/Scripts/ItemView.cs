using UnityEngine;

public class ItemView : MonoBehaviour
{
    [SerializeField] private GameObject highlightObject;
    
    public void Highlight()
    {
        highlightObject.SetActive(true);
    }
    
    public void UnHighlight()
    {
        highlightObject.SetActive(false);
    }
}