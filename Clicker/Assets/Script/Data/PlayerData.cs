
[System.Serializable]
public class PlayerData
{
    public int goldCount;
    public int pointCount;
    public int stageID;
    public int atxCount;
    public int ctcCount;
    public int ctcDamageCount;

    // 생성자란? 형식: 반환타입x, 클래스랑 이름이 똑같다,
    // 매개변수는 있어도 되고 없어도 된다,
    // 생성자의 맴버변수가 매개변수로 사용가능
    public PlayerData(int id, int atx, int ctc, int ctcDamage, int gold, int point)
    {
        stageID = id;
        atxCount = atx;
        ctcCount = ctc;
        goldCount = gold;
        pointCount = point;
        ctcDamageCount = ctcDamage;
    }

    //public  static PlayerData CreateDefaultPlayer(int Id, string IdName)
    //{
    //    switch () 
    //    {
    //        case "":  return new PlayerData(Id, IdName, 100, 10, 5, 0, 0);
    //    }
    //}
}
