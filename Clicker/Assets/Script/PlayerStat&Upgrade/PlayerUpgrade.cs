using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public static PlayerUpgrade Instance;
    public PlayerStat playerStat;
    public StatUpgradeUI statUpgradeUI;
    public UpgradeBtn upgradeBtn;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //GameManager.Instance.playerStat = playerStat;
        //GameManager.Instance.SaveUserData();
    }
    public void SaveUserData()
    {
        var saveStatData = JsonUtility.ToJson(playerStat);

        // 저장
        File.WriteAllText(Application.persistentDataPath + "/UserStatData.txt", saveStatData);

        // 저장 확인
        Debug.Log(Application.persistentDataPath);
    }
    public void LoadUserData()
    {
        if (File.Exists(Application.persistentDataPath + "/UserStatData.txt"))
        {
            string loadData = File.ReadAllText(Application.persistentDataPath + "/UserStatData.txt");
            playerStat = JsonUtility.FromJson<PlayerStat>(loadData);
        }
    }
    
}
