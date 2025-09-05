
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int goldCount;
    public int pointCount;
    public int currentStage;
    public float damage;
    public float criticalDamage;
    public float criticalPacentage;

    public List<WeaponInfo> weaponInfo = new List<WeaponInfo>();

    // 생성자란? 형식: 반환타입x, 클래스랑 이름이 똑같다,
    // 매개변수는 있어도 되고 없어도 된다,
    // 생성자의 맴버변수가 매개변수로 사용가능
    public PlayerData(int stage, int gold, int point, float atxDamage, int ctcpacentage, int ctcDamage)
    {
        goldCount = gold;
        pointCount = point;
        currentStage = stage;
        damage = atxDamage;
        criticalDamage = ctcDamage;
        criticalPacentage = ctcpacentage;

        weaponInfo.Add(new WeaponInfo(1, 0));
        weaponInfo.Add(new WeaponInfo(2, 0));
        weaponInfo.Add(new WeaponInfo(3, 0));
        weaponInfo.Add(new WeaponInfo(4, 0));
        weaponInfo.Add(new WeaponInfo(5, 0));
    }
}

[System.Serializable]
public class WeaponInfo
{
    public int weaponID;
    public int levelInfo;

    public WeaponInfo(int weaponID, int levelInfo)
    {
        this.weaponID = weaponID;
        this.levelInfo = levelInfo;
    }
}
