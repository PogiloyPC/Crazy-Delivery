using UnityEngine;

public abstract class PlayerController : ScriptableObject
{
    public abstract void ControlePlayer();

    protected void ThrowOrder()
    {

    }
}

public class MobilePlayerController : PlayerController
{
    public MobilePlayerController()
    {

    }

    public override void ControlePlayer()
    {

    }
}