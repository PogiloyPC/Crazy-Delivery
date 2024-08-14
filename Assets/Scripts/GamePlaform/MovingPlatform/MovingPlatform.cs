using UnityEngine;
using System.Collections;

public abstract class MovingPlatform : MonoBehaviour, IInteractiveObject
{
    [Header("Rotate")]
    [SerializeField] private bool _isRotatePlatform;

    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _cooldownRotate;

    private void Start()
    {
        if (_isRotatePlatform)
            StartCoroutine(RotatePlatform());
    }

    private IEnumerator RotatePlatform()
    {
        while (true)
        {
            Quaternion startRotation = transform.rotation;

            while (transform.rotation.x < startRotation.x + 180)
            {
                transform.rotation = new Quaternion(transform.rotation.x + _rotateSpeed * Time.deltaTime, transform.rotation.y, 
                    transform.rotation.z, transform.rotation.w);

                yield return new WaitForSeconds(Time.deltaTime);
            }

            yield return new WaitForSeconds(_cooldownRotate);
        }
    }
}