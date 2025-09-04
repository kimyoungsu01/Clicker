
[System.Serializable]
public class PlayerData
{
    public int goldCount;
    public int pointCount;
    public int currentStage;
    public int[] upgradeLevels = new int[5];
    public PlayerStat playerStat;
    
    // 생성자란? 형식: 반환타입x, 클래스랑 이름이 똑같다,
    // 매개변수는 있어도 되고 없어도 된다,
    // 생성자의 맴버변수가 매개변수로 사용가능
    public PlayerData(int stage, int gold, int point,int Data, int lv, PlayerStat playerStat)
    {
        goldCount = gold;
        pointCount = point;
        currentStage = stage;
        this.playerStat = playerStat;
    }

    public void weaponUpgrades() 
    {
        WeaponManager.Instance.upgradeLevels = new int[5];
        return;
    }

}
