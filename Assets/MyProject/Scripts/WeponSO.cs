using UnityEngine;
[CreateAssetMenu(fileName = "weapon", menuName = "ScriptableObject/weapon")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] protected string _name;
    [SerializeField] private int _const;
    [SerializeField] private int _damage;
    [SerializeField] private int _coldown;
    [SerializeField] protected int _range;
    [SerializeField] protected Mesh _mesh;
    [SerializeField] protected Sprite _icon;
    public string Name => _name;
    public int Damage => _damage;
    public int Coldown => _coldown;
    public int Range => _coldown;
    public Mesh Mesh => _mesh;
}
