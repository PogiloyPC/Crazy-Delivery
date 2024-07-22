using NUnit.Framework;
using System;

public class DamageDillerTester : IDamageDiller
{
    private int _damage;

    public DamageDillerTester(int damage)
    {
        _damage = damage;
    }

    public int GetDamage() => _damage;
}

