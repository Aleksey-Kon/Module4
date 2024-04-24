using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "charprogress", menuName = "ScriptableObject/progress")]
public class charprogress : ScriptableObject
{
    
    public List<charinfo> _charinfo;
    [SerializeField] private string _name;
    [SerializeField] private int _level;
    public string Name => _name;
    public int Level => _level;
}
