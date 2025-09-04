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
    public TMPro.TextMeshProUGUI monstername;


    void Awake()
    {
      if(Instance == null) Instance = this;
      else Destroy(gameObject);
    }

    private void Start()
    {
        int index = GameManager.Instance.stagecnt.stagecnt / 10;
        GameObject monster = Resources.Load<GameObject>($"Prefabs/LV{index + 1}enemy");        
        Instantiate(monster, new Vector3(0, 0, 0), Quaternion.identity);
        GameManager.Instance.stagecnt.dungeonname.text = $"{monster.transform.GetComponent<Enemy>().enemyData.enemyName}" + "의 던전";
        monstername.text = monster.transform.GetComponent<Enemy>().enemyData.enemyName;
        GetComponentInChildren<TextMeshProUGUI>().text = monster.transform.GetComponent<Enemy>().enemyData.enemyName;
        GetComponentInChildren<Image>().fillAmount = (float)monster.transform.GetComponent<Enemy>().enemyData.enemyHealth / monster.transform.GetComponent<Enemy>().enemyData.enemyHealth;
    }
    public void Respwan()
    {
        GameManager.Instance.stagecnt.UpdateStage();
        GameManager.Instance.stagecnt.DungeonStage();
        int index = GameManager.Instance.stagecnt.stagecnt / 10;        
        GameObject monster = Resources.Load<GameObject>($"Prefabs/LV{index+1}enemy");
        enemy = Instantiate(monster, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Enemy>();
        GameManager.Instance.stagecnt.dungeonname.text = $"{monster.transform.GetComponent<Enemy>().enemyData.enemyName}" + "의 던전";
        monstername.text = monster.transform.GetComponent<Enemy>().enemyData.enemyName;
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

    
}
