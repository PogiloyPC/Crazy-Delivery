using UnityEngine;

public interface IServer
{
    void TakeOrder(BoxOrder order);
}

public interface IPlayerPoint
{
    Point GetPoint();
}

public interface IPlayer
{
    bool CheckGround();
}