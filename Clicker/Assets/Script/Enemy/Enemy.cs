using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{    
    public Enemydata enemyData;
    public PlayerData playerData;    
    public Animator anim;    
    int EnemyMaxHealth; // 적 최대체력
    private int currentHealth;
    public bool IsDead = false;
    int gold = 5;
    int point = 5;

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

    //private void Update() // 애니메이션 테스트용 나중에 지우기 (히트는 테이크데미지에 다이는 에너미다이에 넣기)
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        if (EventSystem.current.IsPointerOverGameObject())
    //            return;

    //        if (IsDead == false)
    //        {
    //            Takedamage();
    //        }
    //    }
    //}

    public void Takedamage()
    {
        //int damage = Mathf.Max(0, 100  - enemyData.enemyDefence); //playerData.atxCount 나중에변경
        currentHealth -= (int)WeaponManager.Instance.Damage();
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
            IsDead = true;
            anim.SetTrigger("Die");
            Drop();
            CostManager.Instance.moneyScore.Init();
        }
    }
   

    public void DestroyEnemy(bool enemy = true)
    {        
        Destroy(gameObject);
        EnemyManager.Instance.Respwan();
    }


    public void Upgradeenemy()
    {              
         enemyData.enemyHealth += 10 * (GameManager.Instance.stagecnt.stagecnt );
         enemyData.enemyDefence += 1 * (GameManager.Instance.stagecnt.stagecnt );        
        
         enemyData.enemyHealth += 10 * (GameManager.Instance.stagecnt.stagecnt / 5);
         enemyData.enemyDefence += 1 * (GameManager.Instance.stagecnt.stagecnt / 5);
    }

    public void Drop()
    {
        Debug.Log($"코스트매니저{CostManager.Instance.goldCount}");
        Debug.Log($"플레이어업그레이드{PlayerUpgrade.Instance.upgradeBtn.SetGoldUp(gold)}");
        CostManager.Instance.goldCount += (int)PlayerUpgrade.Instance.upgradeBtn.SetGoldUp(gold);
        CostManager.Instance.pointCount += point;
        Debug.Log(CostManager.Instance.goldCount += (int)PlayerUpgrade.Instance.upgradeBtn.SetGoldUp(gold));
        GameManager.Instance.SaveUserData();
    }
    

}

  
