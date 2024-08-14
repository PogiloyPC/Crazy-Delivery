using UnityEngine;

public class DamageDiller : MonoBehaviour, IDamageDiller, IInteractiveObject
{
    [SerializeField] private int _damage;

    public int GetDamage() => _damage;
}
