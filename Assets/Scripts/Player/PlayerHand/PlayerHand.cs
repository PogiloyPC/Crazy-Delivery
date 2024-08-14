using UnityEngine;
using UnityEngine.Events;

public class PlayerHand : MonoBehaviour
{
    public void Initialization(UnityEvent onThrow)
    {
        onThrow.AddListener(ThrowOrderBox);
    }

    private void ThrowOrderBox()
    {

    }
}