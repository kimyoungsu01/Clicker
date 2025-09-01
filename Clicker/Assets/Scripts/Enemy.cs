using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Enemydata enemyData;
    



    void Start()
    {
       if (enemyData != null)
       {
            gameObject.GetComponent<Text>().text = enemyData.enemyName;

           
       }
       else
       {
           Debug.LogWarning("Enemydata ScriptableObject is not assigned.");
        }
    }

   
}

  
