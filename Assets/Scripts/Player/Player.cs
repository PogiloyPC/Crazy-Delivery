using UnityEngine;
using UnityEngine.Events;
using System;

public class Player : Character, IPlayerPoint, IPlayer
{
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private FixedJoystick _fixedJoystick;

    [SerializeField] private Point _playerPoint;
    [SerializeField] private Point _groundPoint;

    [SerializeField] private PlayerOrderPack _playerOrderPack;

    private PlayerMovement _playerMovement;

    private Action<IBoxOrder> _onTakeBoxOrder;

    [SerializeField] private LayerMask _groundMask;

    [SerializeField] private float _forceJump;
    [SerializeField] private float _radiusSphereGround;

    public void Initialization(UnityEvent onJump)
    {
        _playerMovement = new PlayerMovement(_fixedJoystick, _rb, onJump, this, Speed, _forceJump);

        _playerOrderPack.Initialization(out _onTakeBoxOrder);
    }

    public override void GameUpdate()
    {

    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _playerMovement.Moving();
    }

    public Point GetPoint() => _playerPoint;

    public bool CheckGround()
    {
        Collider[] collider = Physics.OverlapSphere(_groundPoint.GetPosition(), _radiusSphereGround, _groundMask);

        if (collider.Length > 0)
            return true;
        else
            return false;
    }

    private void OnCollisionEnter(Collision other)
    {
        IBoxOrder boxOrder = other.gameObject.GetComponent<IBoxOrder>();

        if (boxOrder != null)
            _onTakeBoxOrder.Invoke(boxOrder);
    }
}

