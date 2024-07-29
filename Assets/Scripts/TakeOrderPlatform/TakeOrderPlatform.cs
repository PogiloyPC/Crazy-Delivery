using UnityEngine;

public class TakeOrderPlatform : MonoBehaviour, IPlaceTakeOrder
{
    private bool _isCloseDelivery;

    public bool CheckStateDelivery() => _isCloseDelivery;

    private void OnTriggerEnter(Collider other)
    {
        IBoxOrder boxOrder = other.gameObject.GetComponent<IBoxOrder>();

        if (boxOrder != null && !boxOrder.IsDelivery())
        {
            boxOrder.SetDeliveryState(this);

            if (boxOrder.IsDelivery())
                _isCloseDelivery = true;
        }

    }
}

