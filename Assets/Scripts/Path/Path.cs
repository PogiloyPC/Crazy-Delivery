using UnityEngine;
using System.Collections.Generic;

public class Path : MonoBehaviour, IPath
{
    [SerializeField] private List<Point> _pathPoints;

    [SerializeField] private TypePath _typePath;

    private int _currentPoint;

    private bool _isComeback;

    public Point GetPoint() => _pathPoints[_currentPoint];

    public void ChangePoint(IPathWalkerPlatform pathWalker)
    {
        if (_typePath == TypePath.line)
        {
            if (!_isComeback)
            {
                _currentPoint++;

                if (_currentPoint >= _pathPoints.Count)
                    _isComeback = true;
            }
            else
            {
                _currentPoint--;

                if (_currentPoint <= _pathPoints.Count - _pathPoints.Count)
                    _isComeback = false;
            }
        }
        else
        {
            _currentPoint++;

            if (_currentPoint >= _pathPoints.Count)
                _currentPoint -= _currentPoint;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        
        for (int i = 0; i < _pathPoints.Count; i++)
            Gizmos.DrawLine(_pathPoints[i].GetPosition(), _pathPoints[i + 1].GetPosition());

        if (_typePath == TypePath.loop)
            Gizmos.DrawLine(_pathPoints[_pathPoints.Count - 1].GetPosition(), _pathPoints[0].GetPosition());
    }
}