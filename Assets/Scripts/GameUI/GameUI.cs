using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

public class GameUI : MonoBehaviour
{
    [SerializeField] private List<ViewHert> _viewHerts;

    [SerializeField] private Button _jumpButton;
    [SerializeField] private Button _throwButton;

    public void Initialization(out UnityEvent onJump, out UnityEvent onThrow, out PlayerHealth playerHealth)
    {
        playerHealth = new PlayerHealth(_viewHerts);

        onJump = _jumpButton.onClick;
        onThrow = _throwButton.onClick;
    }
}