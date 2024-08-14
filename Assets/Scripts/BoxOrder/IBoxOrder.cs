using UnityEngine;

public interface IBoxOrder
{
    bool IsDelivery();

    void SetDeliveryState(IPlaceTakeOrder placeTakeOrder);

    void SetParent(IPlayerOrderPack playerOrderPack);
}