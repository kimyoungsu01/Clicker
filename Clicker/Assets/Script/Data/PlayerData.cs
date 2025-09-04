
[System.Serializable]
public class PlayerData
{
    public int goldCount;
    public int pointCount;
    public int stageID;
    public string monsterName;
    public int monsterHPCount;
    public int atxCount;
    public int ctcCount;

    // 생성자란? 형식: 반환타입x, 클래스랑 이름이 똑같다,
    // 매개변수는 있어도 되고 없어도 된다,
    // 생성자의 맴버변수가 매개변수로 사용가능
    public PlayerData(int id, string name, int hp, int atx, int ctc, int gold, int point)
    {
        stageID = id;
        monsterName = name;
        monsterHPCount = hp;
        atxCount = atx;
        ctcCount = ctc;
        goldCount = gold;
        pointCount = point;
    }

    //public  static PlayerData CreateDefaultPlayer(int Id, string IdName)
    //{
    //    switch () 
    //    {
    //        case "":  return new PlayerData(Id, IdName, 100, 10, 5, 0, 0);
    //    }
    //}
}
