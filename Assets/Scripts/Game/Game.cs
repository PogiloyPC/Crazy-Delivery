using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private List<GameMono> _gameObject;

    private void Update()
    {
        foreach (GameMono obj in _gameObject)
            obj.GameUpdate();
    }
}
