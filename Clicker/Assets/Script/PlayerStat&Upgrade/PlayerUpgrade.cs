using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public static PlayerUpgrade Instance;
    public PlayerStat playerStat;
    public UpgradeBtn upgradeBtn;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        playerStat = new PlayerStat(0, 0, 0, 0, 0, 0, 10, 10, 10);
        GameManager.Instance.playerStat = playerStat;
        GameManager.Instance.SaveUserData();
    }

}
