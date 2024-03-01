using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnPaperCollect;
    public static PrinterManager printerManager;

    public delegate void OnDeskArea();
    public static event OnDeskArea OnPaperDrop;
    public static WorkerManager workerManager;

    public delegate void OnMoneyArea();
    public static event OnMoneyArea OnMoneyCollect;

    public delegate void OnBuyArea();
    public static event OnBuyArea OnBuyingDesk;
    public static BuyAreaControl areaToBuy;

    bool isCollecting, isGiving;
    void Start()
    {
        StartCoroutine(CollectEnum());
    }
    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollecting== true)
            {
                OnPaperCollect();
            }
            if (isGiving==true)
            {
                OnPaperDrop();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            OnMoneyCollect();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BuyArea"))
        {
            OnBuyingDesk();
            areaToBuy = other.gameObject.GetComponent<BuyAreaControl>();

        }
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = true;
            printerManager = other.gameObject.GetComponent<PrinterManager>();
        }
        if (other.gameObject.CompareTag("DropArea"))
        {
            isGiving = true;
            workerManager = other.gameObject.GetComponent<WorkerManager>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false;
            printerManager = null;
            
        }
        if (other.gameObject.CompareTag("DropArea"))
        {
            isGiving = false;
            workerManager = null;
        }
        if (other.gameObject.CompareTag("BuyArea"))
        {
            areaToBuy = null;
        }
    }
}
