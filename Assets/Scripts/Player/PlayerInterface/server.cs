using UnityEngine;

public interface IServer
{
    void TakeOrder(BoxOrder order);
}

public interface IPlayerPoint
{
    Point GetPoint();
}

public interface IPlayer : IPlayerPoint
{
    bool CheckGround();
}

public interface IApgradeHandler
{
    void HandleApgrade();
}

public class PLayerHandler : IApgradeHandler
{
    public void HandleApgrade()
    {

    }
}