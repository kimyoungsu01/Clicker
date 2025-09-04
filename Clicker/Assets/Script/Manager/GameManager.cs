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
    //public SceneLoader sceneLoader;
    public Stagecnt stagecnt;

    public Stage stage { get; private set; }
    //public Player player { get; private set; }
    //public Enemy enemy { get; private set; }
    //public Item item { get; private set; }

    
    

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        else if(Instance != null) 
        { 
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        Init();
        SaveUserData();
        LoadUserData();
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
            var loadData = File.ReadAllText(Application.persistentDataPath + "/UserData.txt");
            playerData = JsonUtility.FromJson<PlayerData>(loadData);
        }
        
        else  
        {
            // 스테이지 (넘버) , 몬스터 (이름, hp)
            // 플레이어 (공격력, 크리티컬, 포인트, 골드) 
            playerData = new PlayerData(0,"", 0, 0, 0, 1000, 1000);
            Debug.Log(playerData);
        }
    }

    // 업데이트
    public void carCulate(PlayerData playerData) 
    { 
       
    }

    public void Init() 
    {
        LoadUserData();
        CostManager.Instance.Init(playerData);
    }
  
}
