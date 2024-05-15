using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class inventoryslot : MonoBehaviour
{
    [SerializeField] private GameObject[] _slots;
    [SerializeField] private TMP_Text[] _slotsName;
    [SerializeField] private TMP_Text[] _slotsCoin;
    //[SerializeField] private LootSO _loot;
    public void addslot(LootSO _loot)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (!_slots[i].activeSelf)
            {
                _slots[i].SetActive(true);
                _slotsName[i].text = _loot.Name;
                _slotsCoin[i].text = $"Coin:{_loot.Cost}";
                _slots[i].GetComponent<Image>().sprite = _loot.Icon;
                break;
            }
        }
    }
    public void removeslot()
    {
        foreach (var slot in _slots)
        {
            slot.SetActive(false);
        }
    }
}