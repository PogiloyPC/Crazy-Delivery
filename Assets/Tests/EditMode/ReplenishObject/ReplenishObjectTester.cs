using UnityEngine;

public class ReplenishObjectTester : IReplenishObject
{
    private int _replenishValue;

    public ReplenishObjectTester(int replenishValue)
    {
        _replenishValue = replenishValue;
    }

    public int GetReplenishValue() => _replenishValue;
}
