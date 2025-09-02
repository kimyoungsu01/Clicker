using UnityEngine;

public class CostManager : MonoBehaviour // <-���̵� ��밡���Ѱ�?
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
        pointCount = Point; // ���� ����Ʈ
        goldCount = gold; // ���� ���
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
