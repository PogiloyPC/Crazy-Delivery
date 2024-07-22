using NUnit.Framework;
using UnityEngine;
using System;

public class PlayerHertTest
{
    private PlayerHert _playerHert;

    [SetUp]
    public void Initialize()
    {
        var obj = new GameObject();
        ViewHert viewHert = obj.AddComponent<ViewHert>();

        _playerHert = new PlayerHert(viewHert);
    }

    [Test]
    public void TakeDamage_Take1Damage_Return0()
    {
        TakeDamagePlayer(1);

        Assert.AreEqual(0, _playerHert.GetCurrentHealth());
    }

    [Test]
    public void TakeDamage_Take2Damage_Return0Health()
    {
        TakeDamagePlayer(2);

        Assert.AreEqual(0, _playerHert.GetCurrentHealth());
    }

    [Test]
    public void TakeDamage_Take0Damage_ReturnException()
    {
        Assert.Throws<ArgumentException>(() => TakeDamagePlayer(0));
    }

    private void TakeDamagePlayer(int damage)
    {
        DamageDillerTester damageDiller = new DamageDillerTester(damage);

        _playerHert.TakeDamage(damageDiller);
    }

    [Test]
    public void ReplenishHert_Replenish1Health_Return1Health()
    {
        TakeDamagePlayer(1);

        ReplenishObjectTester replenishObject = new ReplenishObjectTester(1);

        _playerHert.ReplenishHert(replenishObject);

        Assert.AreEqual(1, _playerHert.GetCurrentHealth());
    }

    [Test]
    public void ReplenishHert_Take2Health_Return1Health()
    {
        TakeDamagePlayer(1);

        ReplenishObjectTester replenishObject = new ReplenishObjectTester(2);

        _playerHert.ReplenishHert(replenishObject);

        Assert.AreEqual(1, _playerHert.GetCurrentHealth());
    }

    [Test]
    public void ReplenishHealth_Replenish0Health_ReturnException()
    {
        ReplenishObjectTester replenishObject = new ReplenishObjectTester(0);

        Assert.Throws<ArgumentException>(() => _playerHert.ReplenishHert(replenishObject));
    }
}
