using System.Collections;
using UnityEngine;

public class InitEgg : MonoBehaviour
{
    [SerializeField] private GameObject _egg;
    [SerializeField] private Transform _pointInit;
    [SerializeField] private EndGame endGame;
    private void Start()
    {
        StartCoroutine(InitEggRandom());
    }
    private IEnumerator InitEggRandom()
    {
        while (true) 
        {
            var randomTime = Random.Range(4, 8);
            yield return new WaitForSeconds(randomTime);

            Instantiate(_egg, _pointInit.position, Quaternion.identity, _pointInit);
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
