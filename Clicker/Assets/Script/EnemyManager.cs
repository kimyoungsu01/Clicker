using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    [HideInInspector]public Enemy enemy;

    void Awake()
    {
      if(Instance == null) Instance = this;
      else Destroy(gameObject);
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
}
