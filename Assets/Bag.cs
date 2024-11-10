using System;
using UnityEngine;

public class Bag : MonoBehaviour
{
    private int _eggCount = 0;
    public event Action<int> EggCountChangedEvent; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            ChangeEggsCount();
            Destroy(other.gameObject);
        }
    }

    private void ChangeEggsCount()
    {
        _eggCount += 1;
        EggCountChangedEvent.Invoke(_eggCount);
        Debug.Log("Поймал яйцо");

    }
}
