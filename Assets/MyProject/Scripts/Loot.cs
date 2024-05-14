using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private LootSO _lootData;
    private void OnTriggerEnter(Collider other)
    {
        OnPickUp();
    }

    public LootSO LootData => _lootData;
    public void OnPickUp()
    {
        Player.OnLoot(_lootData.Cost);
        Destroy(gameObject);
    }

}