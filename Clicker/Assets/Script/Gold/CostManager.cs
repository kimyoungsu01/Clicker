using UnityEngine;

public class CostManager : MonoBehaviour // <-없이도 사용가능한가?
{
    public int pointCount { get;  set; }
    public int goldCount { get;  set; }

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

        if (goldCount >= amount)
        {
            goldCount -= amount;
            GameManager.Instance.SaveUserData();
        }

        else
        {
            GameManager.Instance.sceneLoader.OnZeroGold();
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
            GameManager.Instance.sceneLoader.OnZeroGold();
        }

    }
}
