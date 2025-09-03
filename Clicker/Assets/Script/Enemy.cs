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
    public Image hpImage; // 체력바 이미지
    int EnemyMaxHealth; // 적 최대체력
    private int currentHealth;

   

    void Awake()
    {       
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
       if (enemyData != null)
       {
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = enemyData.enemyName; 
            gameObject.GetComponentInChildren<Image>().fillAmount = (float)enemyData.enemyHealth / 100;            
       }
        EnemyMaxHealth = enemyData.enemyHealth;
        currentHealth = enemyData.enemyHealth;
        hpImage.fillAmount = 1f;       
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
        hpImage.fillAmount = (float)currentHealth / EnemyMaxHealth;
        Debug.Log("적 체력: " + currentHealth);
        enemydie();
    }

    public void enemydie()
    {
        if (currentHealth <= 0)
        {
            anim.SetTrigger("Die");   
            Drop();                   
            GameManager.Instance.Respwan();             
        }
    }
   

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }


    public void Upgradeenemy()
    { 
        if(GameManager.Instance.stagecnt.stagecnt % 5 == 0) 
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
           CostManager.Instance.goldCount += 10;
           CostManager.Instance.pointCount += 5;
        }
    }

    public void TurnoffUI()
    {
        if (WeaponManager.Instance.weaponUI.weaponInventoryUI.activeSelf == true)
        {
            gameObject.GetComponentInChildren<Canvas>().enabled = false;
        }
       
    }

    public void TurnonUI()
    {
        if (WeaponManager.Instance.weaponUI.weaponInventoryUI.activeSelf == false)
        {
            gameObject.GetComponentInChildren<Canvas>().enabled = true;
        }
    }



    //데미지 텍스트 추가하기
}

  
