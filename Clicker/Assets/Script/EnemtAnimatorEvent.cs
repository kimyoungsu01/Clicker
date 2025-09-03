using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class EnemyAnimatorEvent : MonoBehaviour
    {
       

        public void DestroyEnemyEvent()
        {
            if (EnemyManager.Instance.enemy != null)
                EnemyManager.Instance.enemy.DestroyEnemy();
        }
    }

