using UnityEngine;

public class PlayerApgrade : MonoBehaviour, IInteractiveObject
{
    [SerializeField] private float _lifeTime;

    private void OnTriggerEnter(Collider other)
    {
        IApgradeHandler apgradeHandler = other.gameObject.GetComponent<IApgradeHandler>();

        if (apgradeHandler != null)
        {

        }
    }
}