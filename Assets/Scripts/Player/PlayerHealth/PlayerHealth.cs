using UnityEngine;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    private Stack<PlayerHert> _playerAliveHerts = new Stack<PlayerHert>();
    private Stack<PlayerHert> _playerBrokeHerts = new Stack<PlayerHert>();

    public bool Immortal { get; private set; }

    public void InitializePlayerHealth(List<IViewHealth> viewsHealth)
    {
        for (int i = 0; i < viewsHealth.Count; i++)
        {
            PlayerHert hert = new PlayerHert(viewsHealth[i]);

            _playerAliveHerts.Push(hert);
        }
    }

    public void TakeDamageDiller(IDamageDiller damageDiller)
    {
        IHert hert = _playerAliveHerts.Peek();
        hert.TakeDamage(damageDiller);

        if (hert.GetCurrentHealth() <= 0)
            _playerBrokeHerts.Push(_playerAliveHerts.Pop());
    }

    public void ReplenishHealth(IReplenishObject replenishObject)
    {
        IHert hert = _playerBrokeHerts.Peek();
        hert.ReplenishHert(replenishObject);

        if (hert.GetCurrentHealth() >= 1)
            _playerAliveHerts.Push(_playerBrokeHerts.Pop());
    }

    public int GetCountHert() => _playerAliveHerts.Count;
}