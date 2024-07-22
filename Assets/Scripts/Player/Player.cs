using UnityEngine;

public class Player : Character
{
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private FixedJoystick _fixedJoystick;

    [SerializeField] private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = new PlayerMovement(_fixedJoystick, _rb, Speed);
    }

    public override void GameUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        _playerMovement.Moving();
    }
}

