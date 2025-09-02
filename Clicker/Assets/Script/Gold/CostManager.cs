using UnityEngine;

public class CostManager : MonoBehaviour // <-없이도 사용가능한가?
{
    public int pointCount { get; private set; }
    public int goldCount { get; private set; }

    public GameObject zeroGold;

    public static CostManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    public CostManager(int Point, int gold) 
    {
        pointCount = Point; // 소지 포인트
        goldCount = gold; // 소지 골드
    }
        

    public void GCost(int amount)
    {
        // 아이템 골드 가격이 가지고 있는 골드 양보다 작다면
        if (goldCount >= amount)
        {
            goldCount -= amount;
            GameManager.Instance.SaveUserData();
        }

        else
        {
            // 아이템 골드 가격이 가지고 있는 골드 양보다 크다면
            OnZeroGold();
        }

    }

    public void PCost(int amount)
    {

        if (pointCount >= amount)
        {
            pointCount -= amount;
            GameManager.Instance.SaveUserData();
        }

        else
        {
            OnZeroGold();
        }

    }

    public void OnZeroGold()
    {
        zeroGold.SetActive(true);
    }
}
