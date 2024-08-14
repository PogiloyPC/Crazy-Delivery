using UnityEngine;

public class Point : MonoBehaviour
{
    public Vector3 GetPosition() => transform.position;

    public Transform GetTransform() => transform;
}
