using System;
public interface IDamageble
{
    public int Health { get; }

    public EventHandler<int> TakeDamage { get; }
}