using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static Unity.Burst.Intrinsics.X86;

public class GameManager : MonoBehaviour
{
    public PlayerData playerData;
    PlayerStat playerStat;
    public Stagecnt stagecnt;

    public Stage stage { get; private set; }
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else if(Instance != null) 
        { 
            Destroy(gameObject); 
        }
    }

    public void SaveUserData() 
    {
        var saveData = JsonUtility.ToJson(playerData);

        // 저장
        File.WriteAllText(Application.persistentDataPath + "/UserData.txt", saveData);

        // 저장 확인
        Debug.Log(Application.persistentDataPath);
    }

    public void LoadUserData() 
    {
        if (File.Exists(Application.persistentDataPath + "/UserData.txt"))
        {
            string loadData = File.ReadAllText(Application.persistentDataPath + "/UserData.txt");
            playerData = JsonUtility.FromJson<PlayerData>(loadData);
        }
        
        else  
        {
            // 스테이지 (넘버) // 플레이어 (포인트, 골드, 플레이어 스텟) 
            playerData = new PlayerData(0, 1000, 1000, 0, 0, playerStat);
            SaveUserData();
        }
    }

    public void Init() 
    {
        if (MainSceneLoader.Instance.isSave == true) 
        {
            LoadUserData();
            //EnemyManager.Instance.Respwan();
        }

        else
            playerData = new PlayerData(0, 1000, 1000, 0, 0, playerStat);

        Debug.Log(playerData);
        CostManager.Instance.Init(playerData);
    }


}