using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private LootSO _lootData;
    [SerializeField] private GameObject _script;
    private void Awake()
    {
        _script = GameObject.FindGameObjectWithTag("script");
    }
    private void OnTriggerEnter(Collider other)
    {
        OnPickUp();
    }

    public LootSO LootData => _lootData;
    public void OnPickUp()
    {
        Player.OnLoot(_lootData.Cost);
        _script.GetComponent<inventoryslot>().addslot(_lootData);
        Destroy(gameObject);
    }
}