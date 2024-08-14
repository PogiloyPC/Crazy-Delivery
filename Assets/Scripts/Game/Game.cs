using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private List<GameMono> _gameObject;

    [SerializeField] private CameraMoving _camera;

    [SerializeField] private Player _player;

    [SerializeField] private GameUI _gameUI;

    private const int _maxDamage = 1;
    private const int _gameTime = 6;

    private void Start()
    {
        PlayerHealth playerHealth;

        _camera.InitCamera(_player);

        UnityEvent onJump = new UnityEvent();
        UnityEvent onThrow = new UnityEvent();

        _gameUI.Initialization(out onJump, out onThrow, out playerHealth);

        _player.Initialization(onJump, onThrow, playerHealth);
    }

    public static int GetGameTime() => _gameTime;

    public static int GetMaxDamagePlayer() => _maxDamage;
}
