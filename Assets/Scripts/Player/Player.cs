using UnityEngine;
using UnityEngine.Events;
using System;

public class Player : Character, IPlayerPoint, IPlayer
{
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private FixedJoystick _fixedJoystick;

    [SerializeField] private AnimationCurve _climbCurve;

    [SerializeField] private Point _playerPoint;
    [SerializeField] private Point _groundPoint;

    [SerializeField] private PlayerOrderPack _playerOrderPack;
    [SerializeField] private PlayerHand _playerHand;
    [SerializeField] private PlayerHandler _playerHandler;
    private PlayerHealth _playerHealth;

    private PlayerMovement _playerMovement;

    [SerializeField] private LayerMask _groundMask;
    
    [SerializeField] private float _forceJump;
    [SerializeField] private float _radiusSphereGround;


    public void Initialization(UnityEvent onJump, UnityEvent onThrow, PlayerHealth playerHealth)
    {
        _playerMovement = new PlayerMovement(_climbCurve, _fixedJoystick, _rb, onJump, this, Speed, _forceJump);
        _playerHand.Initialization(onThrow);
        _playerHealth = playerHealth;
        _playerHandler = new PlayerHandler(_playerHealth, _playerOrderPack);
    }

    public override void GameUpdate()
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
        IInteractiveObject interactiveObject = other.gameObject.GetComponent<IInteractiveObject>();

        if (interactiveObject != null)
            _playerHandler.HandleInteractiveObject(interactiveObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_groundPoint.GetPosition(), _radiusSphereGround);
    }
}

