using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponSaveData
{
    public int weaponID;
    public int level;
    public bool isEquipped;

    public WeaponSaveData(int weaponID, int level, bool isEquipped)
    {
        this.weaponID = weaponID;
        this.level = level;
        this.isEquipped = isEquipped;
    }
}
