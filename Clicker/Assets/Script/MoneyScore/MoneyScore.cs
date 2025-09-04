using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyScore : MonoBehaviour
{
    public TextMeshProUGUI goldScore;
    public TextMeshProUGUI pointScore;


    public void ReadGold() 
    {
        goldScore.text = CostManager.Instance.goldCount.ToString();
    }

    public void ReadPoint() 
    {
        pointScore.text = CostManager.Instance.pointCount.ToString();
    }
    public void Init()
    {
        ReadGold();
        ReadPoint();
    }

}
