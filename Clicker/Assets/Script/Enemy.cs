using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{    
    public Enemydata enemyData;
    public PlayerData playerData;    
    public Animator anim;    
    int EnemyMaxHealth; // 적 최대체력
    private int currentHealth;
    



    void Awake()
    {       
        anim = GetComponentInChildren<Animator>();
        enemyData = Instantiate(enemyData);
    }
    void Start()
    {      
        Upgradeenemy(); 
        EnemyMaxHealth = enemyData.enemyHealth;
        currentHealth = enemyData.enemyHealth;
        EnemyManager.Instance.hpImage.fillAmount = 1f;  
        Debug.Log("적 체력: " + currentHealth);        
    }

    private void Update() // 애니메이션 테스트용 나중에 지우기 (히트는 테이크데미지에 다이는 에너미다이에 넣기)
    {
        if (Input.GetMouseButtonDown(0))
        {
           Takedamage();
        }
       
    }

    public void Takedamage()
    {
        int damage = Mathf.Max(0, 100  - enemyData.enemyDefence); //playerData.atxCount 나중에변경
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, EnemyMaxHealth);
        anim.SetTrigger("Hit");
        anim.SetBool("EditChk", true);
        EnemyManager.Instance.hpImage.fillAmount = (float)currentHealth / EnemyMaxHealth;
        Debug.Log("적 체력: " + currentHealth);
        enemydie();
    }

    public void enemydie()
    {
        if (currentHealth <= 0)
        {
            anim.SetTrigger("Die");   
            Drop();                                     
        }
    }
   

    public void DestroyEnemy()
    {
        Destroy(gameObject);
        EnemyManager.Instance.Respwan();        
    }


    public void Upgradeenemy()
    {              
            enemyData.enemyHealth += 10 * (GameManager.Instance.stagecnt.stagecnt - 1);
            enemyData.enemyDefence += 1 * (GameManager.Instance.stagecnt.stagecnt - 1);        
        
            enemyData.enemyHealth += 10 * (GameManager.Instance.stagecnt.stagecnt / 5);
            enemyData.enemyDefence += 1 * (GameManager.Instance.stagecnt.stagecnt / 5);
    }

    public void Drop()
    { 
        if(enemyData.enemyHealth <= 0)
        {
           CostManager.Instance.goldCount += 10;
           CostManager.Instance.pointCount += 5;
        }
    }

   



    //데미지 텍스트 추가하기
}

  
