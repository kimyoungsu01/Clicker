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
    }

    
    void Takedamage()
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
        }
    }

   
}

  
