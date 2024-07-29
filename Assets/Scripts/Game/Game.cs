using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private List<GameMono> _gameObject;

    [SerializeField] private CameraMoving _camera;

    [SerializeField] private Player _player;

    [SerializeField] private GameUI _gameUI;

    private void Start()
    {
        _camera.InitCamera(_player);

        UnityEvent onJump = new UnityEvent();

        _gameUI.Initialization(out onJump);

        _player.Initialization(onJump);
    }
}
