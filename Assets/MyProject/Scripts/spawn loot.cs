using UnityEngine;
public class spawnloot : MonoBehaviour
{
    [SerializeField] private LootSO _loot;
    [SerializeField] private GameObject _spawnpoint;
    private void Awake()
    {
        Instantiate(_loot.Object, _spawnpoint.transform.position, Quaternion.identity);
    }
}