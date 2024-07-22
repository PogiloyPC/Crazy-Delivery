using NUnit.Framework;
using System;

public class ReplenishObjectTest
{
    private ReplenishObjectTester CreateReplenishObject(int replenishValue) => new ReplenishObjectTester(replenishValue);

    [Test]
    public void Initialization_Set1Damage_Return1Damage() => Assert.AreEqual(1, CreateReplenishObject(1).GetReplenishValue());

    [Test]
    public void Initialization_Set2Damage_Return2Damage() => Assert.AreEqual(2, CreateReplenishObject(2).GetReplenishValue());
}
