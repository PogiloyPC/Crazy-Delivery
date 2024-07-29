using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayerOrderPack : MonoBehaviour, IPlayerOrderPack
{
    private Stack<IBoxOrder> _boxOrders = new Stack<IBoxOrder>();

    private Action<IBoxOrder> _onTakeBoxOrder;

    private void OnEnable()
    {
        _onTakeBoxOrder += TakeBoxOrder;   
    }

    private void OnDisable()
    {
        _onTakeBoxOrder -= TakeBoxOrder;
    }

    public void Initialization(out Action<IBoxOrder> onTakeBoxOrder)
    {
        onTakeBoxOrder = _onTakeBoxOrder;
    }

    private void TakeBoxOrder(IBoxOrder box)
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