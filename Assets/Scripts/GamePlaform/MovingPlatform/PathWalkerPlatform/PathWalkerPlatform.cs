using UnityEngine;

public class PathWalkerPlatform : MovingPlatform, IPathWalkerPlatform
{
    [SerializeField] private Path _path;

    [SerializeField] private TypePathWalker _typePathWalker;

    [SerializeField] private float _speed;
    private float _maxDistance;

    private void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (_path != null)
        {
            if (_typePathWalker == TypePathWalker.lerp)
                transform.position = Vector3.Lerp(transform.position, _path.GetPoint().GetPosition(), _speed * Time.deltaTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, _path.GetPoint().GetPosition(), _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _path.GetPoint().GetPosition()) < _maxDistance)
                _path.ChangePoint(this);
        }
    }
}