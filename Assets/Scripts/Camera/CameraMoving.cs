using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    private Point _playerPoint;
 
    [SerializeField] private Vector3 _offset;

    [SerializeField] private float _damping;

    public void InitCamera(IPlayerPoint playerPoint)
    {
        _playerPoint = playerPoint.GetPoint();
    }

    private void LateUpdate()
    {
        Vector3 direction = new Vector3(_playerPoint.GetPosition().x + _offset.x, _playerPoint.GetPosition().y + _offset.y, _playerPoint.GetPosition().z + _offset.z);

        Vector3 interpolateVector = Vector3.Lerp(transform.position, direction, _damping * Time.deltaTime);

        transform.position = interpolateVector;
    }
}
