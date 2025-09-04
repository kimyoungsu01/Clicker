using System.Collections;
using System.Collections.Generic;
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
    }

    void Start()
    {
        playerStat = new PlayerStat(0, 0, 0, 0, 0, 0, 10, 10, 10, 0);
    }
}
