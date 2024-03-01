using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuyAreaControl : MonoBehaviour
{
    public Image progressImage;
    public GameObject deskGameObject,buyGameObject;
    public float cost, currentMoney,progress;
    public void Buy(int goldAmount)
    {
        currentMoney += goldAmount;
        progress = currentMoney / cost;
        progressImage.fillAmount = progress;
        if (progress >=1)
        {
            buyGameObject.SetActive(false);
            deskGameObject.SetActive(true);
            this.enabled = false;
        }
    }
    
}
