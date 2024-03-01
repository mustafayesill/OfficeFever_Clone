using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    List<GameObject> moneyList = new List<GameObject>();

    public Transform DropPoint,moneyDropPoint;
    public GameObject paperPrefab,moneyPrefab;

    int moneyStack = 10;

    private void Start()
    {
        StartCoroutine(GenerateMoney());
    }
    IEnumerator GenerateMoney()
    {
        while (true)
        {
            float moneyCount = moneyList.Count;
            int rowCount = (int)moneyCount / moneyStack;
            if (paperList.Count>0)
            {
                GameObject temp = Instantiate(moneyPrefab);
                temp.transform.position = new Vector3(moneyDropPoint.position.x, (moneyCount%moneyStack)/20, moneyDropPoint.position.z + ((float)rowCount / 4));
                moneyList.Add(temp);
                RemoveLast();
            }
            
            yield return new WaitForSeconds(0.5f);

        }
    }
    public void GetPaper()
    {
        GameObject temp = Instantiate(paperPrefab);
        temp.transform.position = new Vector3(DropPoint.position.x, 0.8f+((float)paperList.Count / 20), DropPoint.position.z);
        paperList.Add(temp);
    }
    public void RemoveLast()
    {
        if (paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
    }


}
