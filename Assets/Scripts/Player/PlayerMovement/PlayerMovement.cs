using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement
{
    private FixedJoystick _fixedJoystick;

    private Rigidbody _rb;

    private IPlayer _player;

    private readonly float _speed;

    private readonly float _forceJump;

    public PlayerMovement(FixedJoystick fixedJoystick, Rigidbody rb, UnityEvent onJump, IPlayer player, float speed, float forceJump)
    {
        _fixedJoystick = fixedJoystick;

        _rb = rb;

        onJump.AddListener(Jump);

        _player = player;

        _speed = speed;

        _forceJump = forceJump;
    }

    public void Moving()
    {
        Vector3 direction = new Vector3(_fixedJoystick.Horizontal * _speed, _rb.velocity.y, _fixedJoystick.Vertical * _speed);

        _rb.velocity = direction;

        if (_fixedJoystick.Horizontal != 0 || _fixedJoystick.Vertical != 0)
        {
            _rb.rotation = Quaternion.LookRotation(direction);
        }
    }

    public void Jump()
    {
        if (_player.CheckGround())
            _rb.AddForce(Vector3.up * _forceJump, ForceMode.Impulse);
    }
}
