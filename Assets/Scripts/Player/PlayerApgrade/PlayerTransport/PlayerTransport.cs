using UnityEngine;
using System.Threading.Tasks;

public abstract class PlayerTransport : PlayerApgrade
{
    
    
    private async void StartBoost()
    {

        await Task.Delay(Game.GetGameTime());
    }   
}