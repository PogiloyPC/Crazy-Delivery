using UnityEngine;

public class PlayerMovement
{
    private FixedJoystick _fixedJoystick;

    private Rigidbody _rb;

    private readonly float _speed;

    public PlayerMovement(FixedJoystick fixedJoystick, Rigidbody rb, float speed)
    {
        _fixedJoystick = fixedJoystick;

        _rb = rb;

        _speed = speed;
    }

    public void Moving()
    {
        Vector3 vectorMoving = new Vector3(_fixedJoystick.Horizontal * _speed, _rb.velocity.y, _fixedJoystick.Vertical * _speed);

        _rb.velocity = vectorMoving;

        if (_fixedJoystick.Horizontal != 0 || _fixedJoystick.Vertical != 0)
        {
            _rb.rotation = Quaternion.LookRotation(vectorMoving);
        }
    }
}
