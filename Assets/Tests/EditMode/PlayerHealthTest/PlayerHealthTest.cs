using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PlayerHealthTest
{
    private PlayerHealth _playerHealth;

    private List<IViewHealth> CreatePlayerHerts(int countHert)
    {
        List<IViewHealth> viewHerts = new List<IViewHealth>();

        for (int i = 0; i < countHert; i++)
        {
            var obj = new GameObject();

            viewHerts.Add(obj.AddComponent<ViewHert>());
        }

        return viewHerts;
    }

    private PlayerHealth CreatePlayerHealth()
    {
        var obj = new GameObject();
        
        return obj.AddComponent<PlayerHealth>();
    }

    [SetUp]
    public void InitializationPlayerHealth()
    {
        _playerHealth = CreatePlayerHealth();
        _playerHealth.InitializePlayerHealth(CreatePlayerHerts(3));
    }

    [Test]
    public void InitializationPlayerHealth_Set2Health_Return2Health()
    {
        PlayerHealth playerHealth = CreatePlayerHealth();
        playerHealth.InitializePlayerHealth(CreatePlayerHerts(2));

        Assert.AreEqual(2, playerHealth.GetCountHert());
    }

    [Test]
    public void InitializationPlayerHealth_Set3Health_Return3Health()
    {
        PlayerHealth playerHealth = CreatePlayerHealth();
        playerHealth.InitializePlayerHealth(CreatePlayerHerts(3));

        Assert.AreEqual(3, playerHealth.GetCountHert());
    }

    [Test]
    public void TakeDamage_Take1Damage_Return2Health()
    {
        _playerHealth.TakeDamageDiller(new DamageDillerTester(2));

        Assert.AreEqual(2, _playerHealth.GetCountHert());
    }

    [Test]
    public void TakeDamage_Take2Damage_Return1Health()
    {
        _playerHealth.TakeDamageDiller(new DamageDillerTester(1));
        _playerHealth.TakeDamageDiller(new DamageDillerTester(1));

        Assert.AreEqual(1, _playerHealth.GetCountHert());
    }

    [Test]
    public void ReplenishHealth_Take1Health_Return2Health()
    {
        _playerHealth.TakeDamageDiller(new DamageDillerTester(1));
        _playerHealth.TakeDamageDiller(new DamageDillerTester(1));
        _playerHealth.ReplenishHealth(new ReplenishObjectTester(1));

        Assert.AreEqual(2, _playerHealth.GetCountHert());
    }

    [Test]
    public void ReplenishHealth_Take2Health_Return3Health()
    {
        _playerHealth.TakeDamageDiller(new DamageDillerTester(1));
        _playerHealth.TakeDamageDiller(new DamageDillerTester(1));
        _playerHealth.ReplenishHealth(new ReplenishObjectTester(1));
        _playerHealth.ReplenishHealth(new ReplenishObjectTester(1));

        Assert.AreEqual(3, _playerHealth.GetCountHert());
    }

    [Test]
    public void StartImortaliti_SetFalse_ReturnFalse()
    {
        Assert.IsTrue(_playerHealth.Immortal);
    }
}
