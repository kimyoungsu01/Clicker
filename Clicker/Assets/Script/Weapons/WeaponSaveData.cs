using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponSaveData
{
    public int weaponID;
    public int level;
    public bool isEquipped;
    public bool isBuy;

    public WeaponSaveData(int weaponID, int level, bool isEquipped, bool isBuy)
    {
        this.weaponID = weaponID;
        this.level = level;
        this.isEquipped = isEquipped;
        this.isBuy = isBuy;
    }
}
