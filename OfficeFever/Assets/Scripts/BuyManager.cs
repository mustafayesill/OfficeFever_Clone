using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    public int moneyCount=0;
    private void OnEnable()
    {
        TriggerManager.OnMoneyCollect += IncreaseMoney;
        TriggerManager.OnBuyingDesk += BuyArea;
    }

    private void OnDisable()
    {
        TriggerManager.OnMoneyCollect -= IncreaseMoney;
        TriggerManager.OnBuyingDesk -= BuyArea;

    }
    void BuyArea()
    {
        if (TriggerManager.areaToBuy !=null)
        {
            if (moneyCount >=1)
            {
                TriggerManager.areaToBuy.Buy(1);
                moneyCount -= 1; 
            }
        }
    }
    void IncreaseMoney()
    {
        moneyCount += 10;
    }
}
