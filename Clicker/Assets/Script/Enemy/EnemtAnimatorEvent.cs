using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class EnemyAnimatorEvent : MonoBehaviour
    {
    [SerializeField] private Enemy enemy;
       

    public void DestroyEnemyEvent()
        {
               enemy.DestroyEnemy();
        }
    }

