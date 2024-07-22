using NUnit.Framework;

public class DamageDillerTest
{
    private DamageDillerTester CreateDamageDiller(int damage) => new DamageDillerTester(damage);

    [Test]
    public void Initialization_Set1Damage_Return1Damage() => Assert.AreEqual(1, CreateDamageDiller(1).GetDamage());

    [Test]
    public void Initialization_Set2Damage_Return2Damage() => Assert.AreEqual(2, CreateDamageDiller(2).GetDamage());
}
