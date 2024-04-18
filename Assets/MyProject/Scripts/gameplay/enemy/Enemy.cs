using System;
using UnityEngine;
public abstract class Enemy : MonoBehaviour, IDamageble
{
    [Header("Enemy Options")]
    [SerializeField] protected int _maxHealth = 100;
    
    protected int _health;
    protected bool _isAlive = true;
    public int Health => _health;

    public EventHandler<int> TakeDamage => OnTakeDmg;

    protected virtual void Die()
    {
        print("Dead");
        
    }
   
    protected virtual void OnTakeDmg(object sender, int damage)
    {
        if (sender is not attack)
            return;

        if (_health > damage)
            _health -= damage;
        else
        {
            _health = 0;
            Die();
        }

        print($"Health: {_health} | Dmg: {damage}");
    }
}