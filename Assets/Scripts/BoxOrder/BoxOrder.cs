using UnityEngine;

public class BoxOrder : MonoBehaviour, IBoxOrder, IInteractiveObject
{
    private bool _isDelivery;

    public bool IsDelivery() => _isDelivery;

    public void SetDeliveryState(IPlaceTakeOrder placeTakeOrder)
    {
        if (!placeTakeOrder.CheckStateDelivery())
            _isDelivery = true;
    }

    public void SetParent(IPlayerOrderPack playerOrderPack)
    {
        if (playerOrderPack != null)
            transform.SetParent(playerOrderPack.GetTransform());
        else
            transform.SetParent(null);
    }

    private void OnCollisionEnter(Collision other)
    {

    }
}