using UnityEngine;
public class inventory : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryObject;
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.I))
        _inventoryObject.SetActive(!_inventoryObject.activeInHierarchy);
    }
}