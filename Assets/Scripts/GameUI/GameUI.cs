using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button _jumpButton;

    public void Initialization(out UnityEvent onJump)
    {
        onJump = _jumpButton.onClick;     
    }
}