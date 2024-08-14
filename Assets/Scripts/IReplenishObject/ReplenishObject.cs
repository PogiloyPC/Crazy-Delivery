using UnityEngine;

public class ReplenishObject : MonoBehaviour, IReplenishObject, IInteractiveObject
{
    [SerializeField] private int _replenishValue;

    public int GetReplenishValue() => _replenishValue;
}