using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WeaponSaveManager : MonoBehaviour
{
    public static WeaponSaveManager Instance;

    public List<WeaponSaveData> weaponSaveList = new List<WeaponSaveData>();
    private string savePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
            return;
        }

        DontDestroyOnLoad(gameObject);
        savePath = Application.persistentDataPath + "/weapons.json";
    }

    public void SaveWeapons()
    {
        string json = JsonUtility.ToJson(new Wrapper<WeaponSaveData>(weaponSaveList), true);
        File.WriteAllText(savePath, json);
        Debug.Log($"무기 저장 완료: {savePath}");
    }

    public void LoadWeapons()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            var wrapper = JsonUtility.FromJson<Wrapper<WeaponSaveData>>(json);
            weaponSaveList = wrapper.items;
            Debug.Log("무기 데이터 불러오기 완료");
        }
        else
        {
            weaponSaveList = new List<WeaponSaveData>();
            Debug.Log("무기 데이터 없음 → 새로 생성");
        }
    }

    // 무기 데이터 찾기
    public WeaponSaveData GetWeapon(int weaponID)
    {
        return weaponSaveList.Find(w => w.weaponID == weaponID);
    }

    // 없으면 새로 추가
    public WeaponSaveData GetOrCreateWeapon(int weaponID)
    {
        var data = GetWeapon(weaponID);
        if (data == null)
        {
            data = new WeaponSaveData(weaponID, 0, false);
            weaponSaveList.Add(data);
        }
        return data;
    }

    public void ResetWeapons()
    {
        foreach (var w in weaponSaveList)
        {
            w.level = 0;
            w.isEquipped = false;
        }
        SaveWeapons();
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public List<T> items;
        public Wrapper (List<T> items) 
        { 
            this.items = items;
        }
    }
}
