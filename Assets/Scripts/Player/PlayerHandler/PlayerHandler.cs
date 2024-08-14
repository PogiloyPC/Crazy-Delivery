using UnityEngine;

public class PlayerHandler
{
    private PlayerHealth _playerHealth;
    private PlayerOrderPack _orderPack;

    public PlayerHandler(PlayerHealth playerHealth, PlayerOrderPack orderPack)
    {
        _playerHealth = playerHealth;
        _orderPack = orderPack;
    }

    public void HandleInteractiveObject(IInteractiveObject interactiveObject)
    {
        switch (interactiveObject)
        {
            case DamageDiller:
                if (interactiveObject is DamageDiller damageDiller)
                    _playerHealth.TakeDamageDiller(damageDiller);
                break;
            case ReplenishObject:
                if (interactiveObject is ReplenishObject replenishObject)
                    _playerHealth.TakeReplenishObject(replenishObject);
                break;
            case MovingPlatform:
                break;
            case BoxOrder:
                if (interactiveObject is BoxOrder boxOrder)
                    _orderPack.TakeBoxOrder(boxOrder);
                break;
            case PlayerApgrade:
                break;
        }
    }
}
