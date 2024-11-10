using System;
using UnityEngine;

public class WolfDamage : MonoBehaviour
{
    public event Action WolfTookDamageEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            WolfTookDamageEvent.Invoke();
            Debug.Log("Получил урон");
        }
    }
}

