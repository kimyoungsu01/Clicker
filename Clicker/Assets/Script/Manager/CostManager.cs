using UnityEngine;
using UnityEngine.UI;

public class CostManager : MonoBehaviour // <-없이도 사용가능한가?
{
    public int pointCount { get;  set; }
    public int goldCount { get;  set; }
    public PlayerData playerData;
    public MoneyScore moneyScore;

    public GameObject zeroGoldPanel;
    public GameObject zeroPointPanel;

    public static CostManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }


    public void Init(PlayerData Data) 
    {
        Debug.Log(Data);
        playerData = Data;
        goldCount = playerData.goldCount;
        pointCount = playerData.pointCount;
        moneyScore.Init();
    }

    public int GoldSub(int amount)
    {
        
        // 아이템 골드 가격이 가지고 있는 골드 양보다 작다면
        if (goldCount >= amount)
        {
            goldCount -= amount;
            moneyScore.ReadGold();
            GameManager.Instance.SaveUserData();
        }

        else
        {
            // 아이템 골드 가격이 가지고 있는 골드 양보다 크다면
            OnZeroGold();
        }
        return goldCount;
    }

    public int PointSub(int amount)
    {
        if (pointCount >= amount)
        {
            pointCount -= amount;
            moneyScore.ReadPoint();
            GameManager.Instance.SaveUserData();
        }

        else
        {
            OnZeroPoint();
        }
        return pointCount;
    }

    public void OnZeroGold()
    {
        zeroGoldPanel.SetActive(true);
    }

    public void OnZeroPoint()
    {
        zeroPointPanel.SetActive(true);
    }
}
