using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyScore : MonoBehaviour
{
    public TextMeshProUGUI goldScore;
    public TextMeshProUGUI pointScore;

    private void Start()
    {
        if (CostManager.Instance != null) 
        {
            ReadGold();
            ReadPoint();
            Debug.Log("CostManager Instance is null");
        }

        else if (CostManager.Instance == null) 
        {
            Debug.Log("CostManager Instance is null");
        }
        
    }

    public void ReadGold() 
    {
        goldScore.text = CostManager.Instance.goldCount.ToString();
    }

    public void ReadPoint() 
    {
        pointScore.text = CostManager.Instance.pointCount.ToString();
    }

}
