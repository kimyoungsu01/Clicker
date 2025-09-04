
[System.Serializable]
public class PlayerData
{
    public int goldCount;
    public int pointCount;
    public int stageID;
    public int weaponData;
    public int weaponLv;
    public PlayerStat playerStat;
    public int[] upgradeLevels = new int[5];

    // 생성자란? 형식: 반환타입x, 클래스랑 이름이 똑같다,
    // 매개변수는 있어도 되고 없어도 된다,
    // 생성자의 맴버변수가 매개변수로 사용가능
    public PlayerData(int id, int gold, int point,int Data, int lv, PlayerStat playerStat)
    {
        stageID = id;
        goldCount = gold;
        pointCount = point;
        weaponData = Data;
        weaponLv = lv;
        this.playerStat = playerStat;
    }

    public void weaponUpgrades() 
    {
        WeaponManager.Instance.upgradeLevels = new int[5];
        return;
    }
}
