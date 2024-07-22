using UnityEngine;
using System.Collections.Generic;

public class TakeOrderPlatform : MonoBehaviour
{
    [SerializeField] private List<FoodOrder> _ordersStart;

    private Queue<FoodOrder> _orders;

    private void OnTriggerEnter(Collider other)
    {
        IServer server = other.gameObject.GetComponent<IServer>();

        if (server != null)
        {
            server.TakeOrder(_orders.Dequeue());
        }
    }
}

