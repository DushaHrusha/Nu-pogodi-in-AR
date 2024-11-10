using System;
using UnityEngine;

public class Bag : MonoBehaviour
{
    private int _eggCount = 0;
    public event Action<int> EggCountChangedEvent; 
    public event Action WolfTookDamageEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("White"))
        {
            ChangeEggsCount();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Black"))
        {
            WolfTookDamageEvent.Invoke();
            Destroy(other.gameObject);
            Debug.Log("Получил урон");
        }
    }

    private void ChangeEggsCount()
    {
        _eggCount += 1;
        EggCountChangedEvent.Invoke(_eggCount);
        Debug.Log("Поймал яйцо");

    }
}
