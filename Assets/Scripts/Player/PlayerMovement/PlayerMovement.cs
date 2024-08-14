using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;

public class PlayerMovement
{
    private AnimationCurve _climbCurve;

    private FixedJoystick _fixedJoystick;

    private Rigidbody _rb;
    
    private IPlayer _player;

    private readonly float _speed;
    private readonly float _forceJump;
    private readonly float _finishTimeClimb;

    public PlayerMovement(AnimationCurve climbCurve, FixedJoystick fixedJoystick, Rigidbody rb, UnityEvent onJump, IPlayer player, float speed, float forceJump)
    {
        _climbCurve = climbCurve;

        _fixedJoystick = fixedJoystick;

        _rb = rb;

        onJump.AddListener(Jump);

        _player = player;

        _speed = speed;

        _forceJump = forceJump;

        _finishTimeClimb = _climbCurve.keys[_climbCurve.length - 1].time;
    }

    public void Moving()
    {
        Vector3 direction = new Vector3(_fixedJoystick.Horizontal * _speed, _rb.velocity.y, _fixedJoystick.Vertical * _speed);

        _rb.velocity = direction;

        if (_fixedJoystick.Horizontal != 0 || _fixedJoystick.Vertical != 0)
            _rb.rotation = Quaternion.LookRotation(direction);
    }

    private void Jump()
    {
        if (_player.CheckGround())
            _rb.AddForce(Vector3.up * _forceJump, ForceMode.Impulse);
    }

    public async void Climb()
    {
        Point playerPoint = _player.GetPoint();

        Vector3 startPosition = playerPoint.GetPosition();

        Transform playerTransform = playerPoint.GetTransform();

        float currentTimeClimb = 0;

        while (currentTimeClimb <= _finishTimeClimb)
        {
            playerTransform.position = new Vector3(startPosition.x + _climbCurve.Evaluate(currentTimeClimb), startPosition.y + _climbCurve.Evaluate(currentTimeClimb), startPosition.z);

            currentTimeClimb += Time.deltaTime;

            await Task.Delay(6);

            if (currentTimeClimb > _finishTimeClimb)
                break;
        }
    }
}
