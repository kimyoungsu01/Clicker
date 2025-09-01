using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Enemydata enemyData;  
    private Stagecnt stagecnt;
    private PlayerData playerData;
    void Start()
    {
       if (enemyData != null)
       {
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = enemyData.enemyName; 
            gameObject.GetComponentInChildren<Image>().fillAmount = (float)enemyData.enemyHealth / 100;            
       }      
       Upgradeenemy();
    }

    
    public void Takedamage()
    {
        enemyData.enemyHealth -= playerData.atxCount - enemyData.enemyDefence;
        gameObject.GetComponentInChildren<Image>().fillAmount = (float)enemyData.enemyHealth / 100;
        enemydie();
    }

    public void enemydie()
    {
        if (enemyData.enemyHealth <= 0)
        {
            Destroy(gameObject);
            stagecnt.UpdateStage(); 
            Drop();
        }
    }

    public void Upgradeenemy()
    { 
        if(stagecnt.stagecnt % 5 == 0)
        {
            enemyData.enemyHealth += 20;
            enemyData.enemyDefence += 2;
        }
        else
        {
            enemyData.enemyHealth += 10;
            enemyData.enemyDefence += 1;
        }
    }

    public void Drop()
    { 
        if(enemyData.enemyHealth <= 0)
        {
           playerData.goldCount += 10;
           playerData.pointCount += 5;
        }
    }

   //데미지 텍스트 추가하기
}

  
