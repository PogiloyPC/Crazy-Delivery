using UnityEngine;

public abstract class PlayerController : ScriptableObject
{
    public abstract float VerticalMove();

    public abstract float HorizontalMove();
}

public class MobilePlayerController : PlayerController
{
    private FixedJoystick _joystick;

    public MobilePlayerController(FixedJoystick joystick)
    {
        _joystick = joystick;
    }

    public override float HorizontalMove() => _joystick.Horizontal;

    public override float VerticalMove() => _joystick.Vertical;
}

public class PCPlayerController : PlayerController
{
    public override float HorizontalMove() => Input.GetAxis("Horizontal");

    public override float VerticalMove() => Input.GetAxis("Vertical");
}