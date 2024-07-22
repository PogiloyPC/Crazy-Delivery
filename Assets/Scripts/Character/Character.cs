using UnityEngine;

public abstract class Character : GameMono
{
    [SerializeField] private float _speed;

    public float Speed { get { return _speed; } private set { } }
}
