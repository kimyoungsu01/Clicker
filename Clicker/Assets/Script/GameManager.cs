using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerData playerData;
    public SceneLoader sceneLoader;

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
            playerData = new PlayerData(0,"", 0, 0, 0);
        }
    }

    // 에너미 스크립트 활용하여 캐릭터 리스폰 추가
    public void Respwan()
    {
        Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
