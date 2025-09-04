using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    [HideInInspector]public Enemy enemy;
    Enemydata enemyData;
    public Image hpImage; 
    Stagecnt stagecnt;

    void Awake()
    {
      if(Instance == null) Instance = this;
      else Destroy(gameObject);
    }

    private void Start()
    {
        GameObject monster = Resources.Load<GameObject>("Prefabs/LV1enemy");
        Instantiate(monster, new Vector3(0, 0, 0), Quaternion.identity);      
        GetComponentInChildren<TextMeshProUGUI>().text = monster.transform.GetComponent<Enemy>().enemyData.enemyName;
        GetComponentInChildren<Image>().fillAmount = (float)monster.transform.GetComponent<Enemy>().enemyData.enemyHealth / monster.transform.GetComponent<Enemy>().enemyData.enemyHealth;

    }
    public void Respwan()
    {
        GameManager.Instance.stagecnt.UpdateStage();
        GameObject monster = Resources.Load<GameObject>("Prefabs/LV1enemy");
        enemy = Instantiate(monster, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Enemy>();
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

    void Changeenemy()
    {
        if (stagecnt.stagecnt >= 10)
        { 
        
        }
    }
}
