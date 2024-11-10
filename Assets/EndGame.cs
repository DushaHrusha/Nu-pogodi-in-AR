using System;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour 
{
    public int EggWinCount { get; private set; } = 10;
    public int WolfHP {get; private set ;} = 5;
    public event Action GameEndedEvent;
    public WolfDamage wolfDamage;
    public Bag bag;
    public GameObject WinPanel;
    public GameObject EndPanel;
    public TMP_Text HPText;
    public TMP_Text EggsCountText;


    void Start()
    {
        HPText.text = WolfHP.ToString();
        EggsCountText.text = "0";
    }

    private void OnEnable()
    {
        bag.EggCountChangedEvent += TakeEgg;
        wolfDamage.WolfTookDamageEvent += TakeWolfDamage;
        Debug.Log("Ивенты добавлены");
    }

    private void OnDisable()
    {
        bag.EggCountChangedEvent -= TakeEgg;
        wolfDamage.WolfTookDamageEvent -= TakeWolfDamage;
    }

    public void TakeWolfDamage()
    {
        WolfHP -= 1;
        HPText.text = WolfHP.ToString();
        if (WolfHP <= 0)
        {
            GameEndedEvent.Invoke();
            EndGamePanel();
        }
    }
    private void TakeEgg(int eggCount)
    {
        EggsCountText.text = eggCount.ToString();
        if (eggCount == EggWinCount)
        {
            GameEndedEvent.Invoke();
            WinGamePanel();
        }
    }
    public void WinGamePanel()
    {
        WinPanel.SetActive(true);
    }

    public void EndGamePanel()
    {
        EndPanel.SetActive(true);
    }
}
