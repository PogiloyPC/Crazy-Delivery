using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayerOrderPack : MonoBehaviour, IPlayerOrderPack
{
    private Stack<IBoxOrder> _boxOrders = new Stack<IBoxOrder>();

    public void TakeBoxOrder(IBoxOrder box)
    {
        box.SetParent(this);

        _boxOrders.Push(box);
    }

    private IBoxOrder GetBoxOrder()
    {
        IBoxOrder boxOrder = _boxOrders.Pop();
        boxOrder.SetParent(null);

        return boxOrder;
    }

    public Transform GetTransform() => transform;
}