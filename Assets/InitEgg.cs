using System.Collections;
using UnityEngine;

public class InitEgg : MonoBehaviour
{
    [SerializeField] private GameObject _witheEgg;
    [SerializeField] private GameObject _blackEgg;
    [SerializeField] private Transform _pointInit;
    [SerializeField] private EndGame endGame;
    private GameObject[] eggs;

    private void Start()
    {
        StartCoroutine(InitEggRandom());
        eggs = new GameObject[]{_witheEgg, _blackEgg};
    }
    private IEnumerator InitEggRandom()
    {
        while (true) 
        {
            var randomEgg = Random.Range(0, 2);

            var randomTime = Random.Range(4, 10);
            yield return new WaitForSeconds(randomTime);

            Instantiate(eggs[randomEgg], _pointInit.position, Quaternion.identity, _pointInit);
        }
    } 
    void OnEnable()
    {
        endGame.GameEndedEvent += StopIntiEgg;
    }
    void OnDisable()
    {
        endGame.GameEndedEvent -= StopIntiEgg;
    }
    void StopIntiEgg()
    {
        StopAllCoroutines();
    }
}
