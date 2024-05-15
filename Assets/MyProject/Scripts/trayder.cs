using System.Collections.Generic;
using UnityEngine;

public class trayder : MonoBehaviour
{
    [SerializeField] private float _tradeRadius = 5f;
    [SerializeField] private GameObject _player,_script;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            if (Vector3.Distance(transform.position, _player.transform.position) < _tradeRadius)
                Trade();
    }
    private void Trade()
    {
        if (Player.Loot <= 0)
            return;
        Player.OnCoin(Player.Loot);
        _script.GetComponent<inventoryslot>().removeslot();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _tradeRadius);
    }
}
