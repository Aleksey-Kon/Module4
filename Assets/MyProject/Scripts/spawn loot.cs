using UnityEngine;
public class spawnloot : MonoBehaviour
{
    [SerializeField] private LootSO _loot,_loot2;
    [SerializeField] private GameObject _spawnpoint,_spawnpoint2;
    private void Awake()
    {
        Instantiate(_loot.Object, _spawnpoint.transform.position, Quaternion.identity);
        Instantiate(_loot2.Object, _spawnpoint2.transform.position, Quaternion.identity);
    }
}